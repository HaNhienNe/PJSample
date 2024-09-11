using System.IO;

namespace iFareData.Models.Initialization.ini
{
    public abstract class IniFileCreator
    {
        public string PATH_FOLDER { get; set; }
        public string PATH_FILE { get; set; }
        public string Name { get; set; }

        protected IniFileCreator(string fileName, string folderPath)
        {
            Name = fileName;
            PATH_FOLDER = folderPath;
            PATH_FILE = Path.Combine(folderPath, fileName);
        }

        public void CreateIniFile()
        {
            if (!Directory.Exists(PATH_FOLDER))
            {
                Directory.CreateDirectory(PATH_FOLDER);
            }

            Write();
        }

        protected abstract void Write();
        public abstract void LoadFromIniFile();
    }
}
