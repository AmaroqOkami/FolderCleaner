using System.Windows.Forms;

namespace FolderCleaner
{
    public static class ControlExtensions
    {
        public static void DoubleBuffer(this Control control)
        {
            if (SystemInformation.TerminalServerSession) return;
            System.Reflection.PropertyInfo dbProp = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            dbProp.SetValue(control, true, null);
        }
    }
}