namespace FolderCleaner
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.refreshFilesButton = new System.Windows.Forms.Button();
            this.deleteSelectedButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minFileSizeEntry = new System.Windows.Forms.NumericUpDown();
            this.itemList = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusMessage = new System.Windows.Forms.Label();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.unselectAllButton = new System.Windows.Forms.Button();
            this.maxFileSizeEntry = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fileDeletionThread = new System.ComponentModel.BackgroundWorker();
            this.directoryTextBox = new System.Windows.Forms.TextBox();
            this.directorySearchButton = new System.Windows.Forms.Button();
            this.fileDiscoveryThread = new System.ComponentModel.BackgroundWorker();
            this.selectionWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.minFileSizeEntry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFileSizeEntry)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshFilesButton
            // 
            this.refreshFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshFilesButton.Location = new System.Drawing.Point(448, 12);
            this.refreshFilesButton.Name = "refreshFilesButton";
            this.refreshFilesButton.Size = new System.Drawing.Size(110, 23);
            this.refreshFilesButton.TabIndex = 1;
            this.refreshFilesButton.Text = "Refresh List";
            this.refreshFilesButton.UseVisualStyleBackColor = true;
            this.refreshFilesButton.Click += new System.EventHandler(this.refreshFilesButton_Click);
            // 
            // deleteSelectedButton
            // 
            this.deleteSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteSelectedButton.Enabled = false;
            this.deleteSelectedButton.Location = new System.Drawing.Point(448, 41);
            this.deleteSelectedButton.Name = "deleteSelectedButton";
            this.deleteSelectedButton.Size = new System.Drawing.Size(110, 23);
            this.deleteSelectedButton.TabIndex = 2;
            this.deleteSelectedButton.Text = "Delete";
            this.deleteSelectedButton.UseVisualStyleBackColor = true;
            this.deleteSelectedButton.Click += new System.EventHandler(this.deleteSelectedButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 300);
            this.progressBar.Maximum = 255;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(546, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minimum file size";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "MB";
            // 
            // minFileSizeEntry
            // 
            this.minFileSizeEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minFileSizeEntry.Location = new System.Drawing.Point(448, 134);
            this.minFileSizeEntry.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.minFileSizeEntry.Name = "minFileSizeEntry";
            this.minFileSizeEntry.Size = new System.Drawing.Size(85, 20);
            this.minFileSizeEntry.TabIndex = 7;
            this.minFileSizeEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minFileSizeEntry.ThousandsSeparator = true;
            this.minFileSizeEntry.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minFileSizeEntry.ValueChanged += new System.EventHandler(this.minFileSizeEntry_ValueChanged);
            // 
            // itemList
            // 
            this.itemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemList.CheckBoxes = true;
            this.itemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderSize});
            this.itemList.Enabled = false;
            this.itemList.Location = new System.Drawing.Point(12, 12);
            this.itemList.Name = "itemList";
            this.itemList.Size = new System.Drawing.Size(427, 238);
            this.itemList.TabIndex = 8;
            this.itemList.UseCompatibleStateImageBehavior = false;
            this.itemList.View = System.Windows.Forms.View.Details;
            this.itemList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.itemList_ColumnClick);
            this.itemList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.itemList_OnCheck);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Filename";
            this.columnHeaderName.Width = 319;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Filesize";
            this.columnHeaderSize.Width = 104;
            // 
            // statusMessage
            // 
            this.statusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.statusMessage.AutoSize = true;
            this.statusMessage.Location = new System.Drawing.Point(9, 284);
            this.statusMessage.MaximumSize = new System.Drawing.Size(546, 0);
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(209, 13);
            this.statusMessage.TabIndex = 9;
            this.statusMessage.Text = "Ready to begin. Click \'Refresh List\' to start.";
            // 
            // selectAllButton
            // 
            this.selectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectAllButton.Enabled = false;
            this.selectAllButton.Location = new System.Drawing.Point(448, 198);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(110, 23);
            this.selectAllButton.TabIndex = 10;
            this.selectAllButton.Text = "Select All";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // unselectAllButton
            // 
            this.unselectAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.unselectAllButton.Enabled = false;
            this.unselectAllButton.Location = new System.Drawing.Point(448, 227);
            this.unselectAllButton.Name = "unselectAllButton";
            this.unselectAllButton.Size = new System.Drawing.Size(110, 23);
            this.unselectAllButton.TabIndex = 11;
            this.unselectAllButton.Text = "Unselect All";
            this.unselectAllButton.UseVisualStyleBackColor = true;
            this.unselectAllButton.Click += new System.EventHandler(this.unselectAllButton_Click);
            // 
            // maxFileSizeEntry
            // 
            this.maxFileSizeEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxFileSizeEntry.Location = new System.Drawing.Point(448, 88);
            this.maxFileSizeEntry.Maximum = new decimal(new int[] {
            0,
            2048,
            0,
            0});
            this.maxFileSizeEntry.Name = "maxFileSizeEntry";
            this.maxFileSizeEntry.Size = new System.Drawing.Size(85, 20);
            this.maxFileSizeEntry.TabIndex = 14;
            this.maxFileSizeEntry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxFileSizeEntry.ThousandsSeparator = true;
            this.maxFileSizeEntry.ValueChanged += new System.EventHandler(this.maxFileSizeEntry_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "MB";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Maximum file size";
            // 
            // fileDeletionThread
            // 
            this.fileDeletionThread.WorkerReportsProgress = true;
            this.fileDeletionThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileDeletionThread_DoWork);
            this.fileDeletionThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileDeletionThread_ProgressChanged);
            this.fileDeletionThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileDiscoveryThread_RunWorkerCompleted);
            // 
            // directoryTextBox
            // 
            this.directoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryTextBox.Location = new System.Drawing.Point(12, 261);
            this.directoryTextBox.Name = "directoryTextBox";
            this.directoryTextBox.Size = new System.Drawing.Size(427, 20);
            this.directoryTextBox.TabIndex = 15;
            this.directoryTextBox.Text = "C:\\Users\\Eli-PC\\Downloads";
            this.directoryTextBox.TextChanged += new System.EventHandler(this.directoryTextBox_TextChanged);
            // 
            // directorySearchButton
            // 
            this.directorySearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.directorySearchButton.Location = new System.Drawing.Point(448, 259);
            this.directorySearchButton.Name = "directorySearchButton";
            this.directorySearchButton.Size = new System.Drawing.Size(110, 23);
            this.directorySearchButton.TabIndex = 16;
            this.directorySearchButton.Text = "Browse...";
            this.directorySearchButton.UseVisualStyleBackColor = true;
            this.directorySearchButton.Click += new System.EventHandler(this.directorySearchButton_Click);
            // 
            // fileDiscoveryThread
            // 
            this.fileDiscoveryThread.WorkerReportsProgress = true;
            this.fileDiscoveryThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileDiscoveryThread_DoWork);
            this.fileDiscoveryThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.fileDiscoveryThread_ProgressChanged);
            this.fileDiscoveryThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileDiscoveryThread_RunWorkerCompleted);
            // 
            // selectionWorker
            // 
            this.selectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.selectionWorker_DoWork);
            this.selectionWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.selectionWorker_RunWorkerCompleted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 335);
            this.Controls.Add(this.directorySearchButton);
            this.Controls.Add(this.directoryTextBox);
            this.Controls.Add(this.maxFileSizeEntry);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.unselectAllButton);
            this.Controls.Add(this.selectAllButton);
            this.Controls.Add(this.statusMessage);
            this.Controls.Add(this.itemList);
            this.Controls.Add(this.minFileSizeEntry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.deleteSelectedButton);
            this.Controls.Add(this.refreshFilesButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(586, 305);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Folder Cleaner";
            ((System.ComponentModel.ISupportInitialize)(this.minFileSizeEntry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFileSizeEntry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button refreshFilesButton;
        private System.Windows.Forms.Button deleteSelectedButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown minFileSizeEntry;
        private System.Windows.Forms.ListView itemList;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.Label statusMessage;
        private System.Windows.Forms.Button selectAllButton;
        private System.Windows.Forms.Button unselectAllButton;
        private System.Windows.Forms.NumericUpDown maxFileSizeEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker fileDeletionThread;
        private System.Windows.Forms.TextBox directoryTextBox;
        private System.Windows.Forms.Button directorySearchButton;
        private System.ComponentModel.BackgroundWorker fileDiscoveryThread;
        private System.ComponentModel.BackgroundWorker selectionWorker;
    }
}

