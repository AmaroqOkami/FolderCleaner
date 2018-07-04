using System;
using System.IO;
using System.Xml.Serialization;

namespace FolderCleaner
{
    public class DLC_Options
    {
        private const string settingsFileName = "FolderCleanerSettings.xml";
        private static DLC_Options _instance;

        public static DLC_Options Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateFromFile();
                }

                return _instance;
            }
        }

        //All option variables are put here.
        public long minFileSize;
        public long maxFileSize;
        public string folderPath;
        public int winPosX;
        public int winPosY;

        public DLC_Options()
        {
            minFileSize = 1048576;
            maxFileSize = long.MaxValue;
            folderPath = Program.dlFilePath;
            winPosX = 500;
            winPosY = 500;
    }


        public void Save()
        {
            if (maxFileSize == long.MaxValue)
                this.maxFileSize = 0;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(DLC_Options));
                TextWriter writer = new StreamWriter(settingsFileName);
                ser.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex);
            }

            if (maxFileSize == 0)
                this.maxFileSize = long.MaxValue;
        }

        public static DLC_Options CreateFromFile()
        {
            if (!File.Exists(settingsFileName)) return new DLC_Options();

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(DLC_Options));
                TextReader reader = new StreamReader(settingsFileName);
                DLC_Options instance = (DLC_Options)ser.Deserialize(reader);
                reader.Close();

                if (instance.maxFileSize == 0)
                    instance.maxFileSize = long.MaxValue;

                return instance;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex);

                return new DLC_Options();
            }
        }
    }
}
