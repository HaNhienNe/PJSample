using iFareData.Component.Constant;
using System.IO;
using System.Text;

namespace iFareData.Models.Initialization.ini
{
    public class IFareDataIni : IniFileCreator
    {
        public Connect CONNECT { get; set; }
        public Log LOG { get; set; }
        public Setting SETTING { get; set; }

        public IFareDataIni() : base(IFareDataConstant.CONFIG_FILE_NAME, Constant.CONFIG_FOLDER_PATH)
        {
            CONNECT = new Connect();
            LOG = new Log();
            SETTING = new Setting();
        }

        protected override void Write()
        {
            var content = new StringBuilder();
            content.AppendLine("[CONNECT]");
            content.AppendLine($"CONNECT_SETTING={CONNECT.CONNECT_SETTING}");
            content.AppendLine($"ADDRESS={CONNECT.ADDRESS}");
            content.AppendLine($"PORT={CONNECT.PORT}");
            content.AppendLine($"CONNECT_USER={CONNECT.CONNECT_USER}");
            content.AppendLine($"CONNECT_PASSWORD={CONNECT.CONNECT_PASSWORD}");
            content.AppendLine("[LOG]");
            content.AppendLine($"ERRORLOG_DELETE={LOG.ERRORLOG_DELETE}");
            content.AppendLine("[SETTING]");
            content.AppendLine($"FRSRQ_RETRY={SETTING.FRSRQ_RETRY}");
            content.AppendLine($"FRSRQ_WAIT={SETTING.FRSRQ_WAIT}");

            File.WriteAllText(PATH_FILE, content.ToString());
        }

        public override void LoadFromIniFile()
        {

            var lines = File.ReadAllLines(PATH_FILE);
            var currentSection = string.Empty;

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();

                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith(";"))
                {
                    continue;
                }

                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentSection = trimmedLine.Trim('[', ']').ToUpper();
                    continue;
                }

                var parts = trimmedLine.Split(new[] { '=' }, 2);
                if (parts.Length != 2)
                {
                    continue; // Invalid line format
                }

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (currentSection)
                {
                    case "CONNECT":
                        ReadConnect(key, value);
                        break;
                    case "LOG":
                        ReadLog(key, value);
                        break;
                    case "SETTING":
                        ReadSetting(key, value);
                        break;
                }
            }
        }

        private void ReadConnect(string key, string value)
        {
            switch (key)
            {
                case "CONNECT_SETTING":
                    CONNECT.CONNECT_SETTING = int.TryParse(value, out var connectSetting) ? connectSetting : Constant.ZERO_NUMBER;
                    break;
                case "ADDRESS":
                    CONNECT.ADDRESS = value;
                    break;
                case "PORT":
                    CONNECT.PORT = value;
                    break;
                case "CONNECT_USER":
                    CONNECT.CONNECT_USER = value;
                    break;
                case "CONNECT_PASSWORD":
                    CONNECT.CONNECT_PASSWORD = value;
                    break;
            }
        }

        private void ReadLog(string key, string value)
        {
            if (key == "ERRORLOG_DELETE")
            {
                LOG.ERRORLOG_DELETE = int.TryParse(value, out var errorLogDelete) ? errorLogDelete : IFareDataConstant.ERRORLOG_DELETE;
            }
        }

        private void ReadSetting(string key, string value)
        {
            switch (key)
            {
                case "FRSRQ_RETRY":
                    SETTING.FRSRQ_RETRY = int.TryParse(value, out var frsrqRetry) ? frsrqRetry : IFareDataConstant.FRSRQ_RETRY;
                    break;
                case "FRSRQ_WAIT":
                    SETTING.FRSRQ_WAIT = int.TryParse(value, out var frsrqWait) ? frsrqWait : IFareDataConstant.FRSRQ_WAIT;
                    break;
            }
        }
    }
    public class Connect
    {
        public int CONNECT_SETTING { get; set; }
        public string ADDRESS { get; set; }
        public string PORT { get; set; }
        public string CONNECT_USER { get; set; }
        public string CONNECT_PASSWORD { get; set; }
        public Connect()
        {
            CONNECT_SETTING = Constant.ZERO_NUMBER;
            ADDRESS = Constant.BLANK_VALUE;
            PORT = Constant.BLANK_VALUE;
            CONNECT_USER = Constant.BLANK_VALUE;
            CONNECT_PASSWORD = Constant.BLANK_VALUE;
        }
    }

    public class Log
    {
        public int ERRORLOG_DELETE { get; set; }

        public Log()
        {
            ERRORLOG_DELETE = IFareDataConstant.ERRORLOG_DELETE;
        }
    }

    public class Setting
    {
        public int FRSRQ_RETRY { get; set; }
        public int FRSRQ_WAIT { get; set; }

        public Setting()
        {
            FRSRQ_RETRY = IFareDataConstant.FRSRQ_RETRY; // 2 
            FRSRQ_WAIT = IFareDataConstant.FRSRQ_WAIT;   // 5
        }
    }
}
