using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FolderCleaner
{
    static class Program
    {
        public static readonly string dlFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

        public static Dictionary<string, string> fileList = new Dictionary<string, string>();
        public static Dictionary<string, long> fileListSize = new Dictionary<string, long>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        public static string ToFileSize(this double value)
        {
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"};
            for (int i = 0; i < suffixes.Length; i++)
            {
                if (value <= (Math.Pow(1024, i + 1)))
                {
                    return OnlyFourDigits(value / Math.Pow(1024, i)) + " " + suffixes[i];
                }
            }

            return OnlyFourDigits(value / Math.Pow(1024, suffixes.Length - 1)) + " " + suffixes[suffixes.Length - 1];
        }

        public static string OnlyFourDigits(double num)
        {
            if (num < 10)
                return num.ToString("0.000");
            else if (num < 100)
                return num.ToString("00.00");
            else if (num < 1000)
                return num.ToString("000.0");
            else
                return num.ToString("N0");
        }

        public class ListViewItemComparer : System.Collections.IComparer
        {

            private int col;
            private SortOrder order;

            public ListViewItemComparer()
            {
                col = 1;
                order = SortOrder.Ascending;
            }

            public ListViewItemComparer(int column, SortOrder order)
            {
                col = column;
                this.order = order;
            }

            public int Compare(object x, object y)
            {
                int returnVal = -1;

                if (col == 1)
                {
                    returnVal = fileListSize[((ListViewItem)x).SubItems[0].Text].CompareTo(fileListSize[((ListViewItem)y).SubItems[0].Text]);
                    if (order == SortOrder.Descending)
                    { returnVal *= -1; }
                }
                else
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    if (order == SortOrder.Descending)
                    { returnVal *= -1; }
                }

                return returnVal;
            }


        }
    }
}
