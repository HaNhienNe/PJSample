using iFareData.Component.Constant;
using System;
using System.IO;
using System.Text;

namespace iFareData.Models.Initialization.ini
{
    public class SwsURLIni : IniFileCreator
    {
        public Url URL { get; set; }
        public Version VERSION { get; set; }

        public SwsURLIni() : base(IFareDataConstant.SWS_URL_FILE_NAME, Constant.CONFIG_FOLDER_PATH)
        {
            URL = new Url();
            VERSION = new Version();
        }

        protected override void Write()
        {
            var content = new StringBuilder();
            content.AppendLine("[URL]");
            content.AppendLine($"URL={URL.URL}");
            content.AppendLine("[VERSION]");
            content.AppendLine($"CONTRACT_VERSION={VERSION.CONTRACT_VERSION}");
            content.AppendLine($"STATUSRQ_VERSION={VERSION.STATUSRQ_VERSION}");

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
                    case "URL":
                        ReadURL(key, value);
                        break;
                    case "VERSION":
                        ReadVersion(key, value);
                        break;
                }
            }
        }

        private void ReadURL(string key, string value)
        {
            if (key == "URL")
            {
                URL.URL = value;
            }

        }

        private void ReadVersion(string key, string value)
        {

            switch (key)
            {
                case "CONTRACT_VERSION":
                    VERSION.CONTRACT_VERSION = value;
                    break;
                case "STATUSRQ_VERSION":
                    VERSION.STATUSRQ_VERSION = value;
                    break;
            }
        }
    }

    public class Url
    {
        public string URL { get; set; }

        public Url()
        {
            URL = IFareDataConstant.URL_SWS_CERT;
        }
    }

    public class Version
    {
        public string CONTRACT_VERSION { get; set; }
        public string STATUSRQ_VERSION { get; set; }

        public Version()
        {
            CONTRACT_VERSION = IFareDataConstant.CONTRACT_VERSION;
            STATUSRQ_VERSION = IFareDataConstant.STATUSRQ_VERSION;
        }
    }
}
