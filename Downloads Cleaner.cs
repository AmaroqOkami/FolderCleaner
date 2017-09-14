using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FolderCleaner
{
    public partial class MainWindow : Form
    {
        private byte sortColumn = 1;
        private SortOrder currentOrder = SortOrder.Descending;

        private CommonOpenFileDialog fileDiscoveryDialog;

        private ushort workProgressValue = 0;
        private string workProgressMessage = "";

        private bool selectEnabling = false;

        private bool programInitializing = true;

        public MainWindow()
        {
            InitializeComponent();

            this.SizeChanged += new EventHandler(itemList_Resize);
            this.itemList.DoubleBuffer();

            if (DLC_Options.Instance.maxFileSize >= maxFileSizeEntry.Maximum * 1000000)
                this.maxFileSizeEntry.Value = 0;
            else
                this.maxFileSizeEntry.Value = DLC_Options.Instance.maxFileSize / 1048576;

            this.minFileSizeEntry.Value = DLC_Options.Instance.minFileSize / 1048576;
            this.directoryTextBox.Text = DLC_Options.Instance.folderPath;

            this.fileDiscoveryDialog = new CommonOpenFileDialog();
            this.fileDiscoveryDialog.EnsurePathExists = true;
            this.fileDiscoveryDialog.IsFolderPicker = true;
            this.fileDiscoveryDialog.InitialDirectory = DLC_Options.Instance.folderPath;

            programInitializing = false;
        }

        private void minFileSizeEntry_ValueChanged(object sender, EventArgs e)
        {
            if (!programInitializing)
            {
                DLC_Options.Instance.minFileSize = (long)(minFileSizeEntry.Value) * 1048576;
                DLC_Options.Instance.Save();
            }
        }
        private void maxFileSizeEntry_ValueChanged(object sender, EventArgs e)
        {
            if (!programInitializing)
            {
                if (maxFileSizeEntry.Value != 0)
                    DLC_Options.Instance.maxFileSize = (long)(maxFileSizeEntry.Value) * 1048576;
                else
                    DLC_Options.Instance.maxFileSize = long.MaxValue;

                DLC_Options.Instance.Save();
            }
        }

        private void itemList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                if (currentOrder == SortOrder.Ascending)
                    currentOrder = SortOrder.Descending;
                else
                    currentOrder = SortOrder.Ascending;
            }
            else if (e.Column == 1)
                currentOrder = SortOrder.Ascending;
            else
                currentOrder = SortOrder.Descending;

            sortColumn = (byte)(e.Column);
            itemList.ListViewItemSorter = new Program.ListViewItemComparer(e.Column, currentOrder);
        }

        private void itemList_Resize(object sender, System.EventArgs e)
        {
            itemList.Columns[0].Width = 319 + (this.Width - 586);
        }

        //File discovery stuff
        private void refreshFilesButton_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(DLC_Options.Instance.folderPath))
            {
                refreshFilesButton.Enabled = false;
                deleteSelectedButton.Enabled = false;
                selectAllButton.Enabled = false;
                unselectAllButton.Enabled = false;
                itemList.Enabled = true;

                itemList.Items.Clear();
                Program.fileList.Clear();
                Program.fileListSize.Clear();
                itemList.ListViewItemSorter = null;

                workProgressMessage = "";
                workProgressValue = 0;

                fileDiscoveryThread.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Selected folder not found.");
            }
        }

        private void fileDiscoveryThread_DoWork(object sender, DoWorkEventArgs e)
        {
            var fileList = Directory.EnumerateFiles(DLC_Options.Instance.folderPath);
            progressBar.Maximum = fileList.Count();

            foreach (string file in fileList)
            {
                try
                {
                    FileInfo fInfo = new FileInfo(file);
                    if (fInfo.Length > DLC_Options.Instance.minFileSize && fInfo.Length < DLC_Options.Instance.maxFileSize)
                    {
                        string[] fileInfo = { fInfo.Name, Program.ToFileSize(fInfo.Length) };

                        workProgressMessage = "Adding: " + fInfo.Name;
                        workProgressValue++;

                        fileDiscoveryThread.ReportProgress(0);

                        itemList.Items.Add(new ListViewItem(fileInfo));
                        Program.fileList.Add(fInfo.Name, file);
                        Program.fileListSize.Add(fInfo.Name, fInfo.Length);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
            }
        }

        private void fileDiscoveryThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusMessage.Text = workProgressMessage;
            progressBar.Value = workProgressValue;
        }

        private void fileDiscoveryThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else if (e.Cancelled)
                statusMessage.Text = "Operation cancelled.";
            else
            {
                currentOrder = SortOrder.Descending;
                itemList.ListViewItemSorter = new Program.ListViewItemComparer(1, currentOrder);

                refreshFilesButton.Enabled = true;
                deleteSelectedButton.Enabled = true;
                selectAllButton.Enabled = true;
                unselectAllButton.Enabled = true;

                statusMessage.Text = itemList.Items.Count + " files found.";
                progressBar.Value = 0;
            }
        }

        private void itemList_OnCheck(object sender, EventArgs e)
        {
            if (!fileDiscoveryThread.IsBusy && !selectionWorker.IsBusy && !fileDeletionThread.IsBusy)
            {
                if (itemList.CheckedItems.Count == 1)
                    statusMessage.Text = "1 item selected.";
                else
                    statusMessage.Text = itemList.CheckedItems.Count + " items selected.";
            }
        }

        //File Deletion handling
        private void deleteSelectedButton_Click(object sender, EventArgs e)
        {
            if (itemList.CheckedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("All selected files will be sent to the recycle bin.\nAre you sure you want to do this?", "Alert", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    deleteSelectedButton.Enabled = false;
                    refreshFilesButton.Enabled = false;

                    workProgressValue = 0;
                    workProgressMessage = "";

                    progressBar.Maximum = itemList.CheckedItems.Count;
                    fileDeletionThread.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("No files selected.");
            }
        }

        private void fileDeletionThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int deleteCount = 0;

            foreach (ListViewItem item in itemList.CheckedItems)
            {
                if (Program.fileList.TryGetValue(item.SubItems[0].Text, out string filePath))
                {
                    if (File.Exists(filePath))
                        FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

                    workProgressMessage = "Deleting: " + item.SubItems[0].Text;
                    workProgressValue++;

                    fileDeletionThread.ReportProgress(0);

                    Program.fileList.Remove(item.SubItems[0].Text);
                    Program.fileListSize.Remove(item.SubItems[0].Text);
                    itemList.Items.Remove(item);

                    if (!File.Exists(filePath))
                        deleteCount++;
                }
            }

            e.Result = deleteCount;
        }

        private void fileDeletionThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else if (e.Cancelled)
                statusMessage.Text = "Operation cancelled.";
            else
            {
                if ((int)(e.Result) == 1)
                    MessageBox.Show("1 file has been successfully deleted.");
                else
                    MessageBox.Show((int)(e.Result) + " files have been successfully deleted.");

                if (itemList.Items.Count == 0)
                    itemList.Enabled = false;

                statusMessage.Text = (int)(e.Result) + " files removed.";
                deleteSelectedButton.Enabled = true;
                refreshFilesButton.Enabled = true;
            }
        }

        private void fileDeletionThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            statusMessage.Text = workProgressMessage;
            progressBar.Value = workProgressValue;
        }


        //Directory selection stuff
        private void directorySearchButton_Click(object sender, EventArgs e)
        {
            if (fileDiscoveryDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                fileDiscoveryDialog.InitialDirectory = fileDiscoveryDialog.FileName;

                DLC_Options.Instance.folderPath = fileDiscoveryDialog.FileName;
                directoryTextBox.Text = fileDiscoveryDialog.FileName;

                DLC_Options.Instance.Save();
            }
        }

        private void directoryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!programInitializing)
            {
                DLC_Options.Instance.folderPath = directoryTextBox.Text;
                DLC_Options.Instance.Save();
            }
        }

        //Select buttons
        private void selectAllButton_Click(object sender, EventArgs e)
        {
            refreshFilesButton.Enabled = false;
            deleteSelectedButton.Enabled = false;
            selectAllButton.Enabled = false;
            unselectAllButton.Enabled = false;

            statusMessage.Text = "Selecting all items...";

            selectEnabling = true;
            selectionWorker.RunWorkerAsync();
        }

        private void unselectAllButton_Click(object sender, EventArgs e)
        {
            refreshFilesButton.Enabled = false;
            deleteSelectedButton.Enabled = false;
            selectAllButton.Enabled = false;
            unselectAllButton.Enabled = false;

            statusMessage.Text = "Unselecting all items...";

            selectEnabling = false;
            selectionWorker.RunWorkerAsync();
        }

        private void selectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < this.itemList.Items.Count; i++)
                itemList.Items[i].Checked = selectEnabling;

            e.Result = itemList.CheckedItems.Count;
        }

        private void selectionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refreshFilesButton.Enabled = true;
            deleteSelectedButton.Enabled = true;
            selectAllButton.Enabled = true;
            unselectAllButton.Enabled = true;

            statusMessage.Text = e.Result + " items selected.";
        }
    }
}
