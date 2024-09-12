using iFareData.Models.Initialization.ini;
using iFareData.Service.Interfaces.Initialization;
using System.IO;

namespace iFareData.Service.impl.Initialization
{
    internal class AppInitializer : IAppInitializer
    {
         IniFileCreator iFareDataIni = new IFareDataIni();
         IniFileCreator swsURLIni = new SwsURLIni();
        public void InitializeFoldersAndFiles()
        {
            if (!Directory.Exists(iFareDataIni.PATH_FOLDER) || !File.Exists(iFareDataIni.PATH_FILE))
            {
                iFareDataIni.CreateIniFile();
            }

            if (!Directory.Exists(swsURLIni.PATH_FOLDER) || !File.Exists(swsURLIni.PATH_FILE))
            {
                swsURLIni.CreateIniFile();
            }

            iFareDataIni.LoadFromIniFile();
            swsURLIni.LoadFromIniFile();
        }

        public IFareDataIni getIFareDataIni()
        {
            return (IFareDataIni)iFareDataIni;
        }
        public SwsURLIni getSwsURLIni()
        {
            return (SwsURLIni)swsURLIni;
        }



    }
}
