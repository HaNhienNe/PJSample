using iFareData.Models.Initialization.ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFareData.Service.Interfaces.Initialization
{
    internal interface IAppInitializer
    {
        void InitializeFoldersAndFiles();

        public IFareDataIni getIFareDataIni();
        public SwsURLIni getSwsURLIni();
    }
}
