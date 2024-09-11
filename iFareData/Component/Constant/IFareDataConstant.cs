namespace iFareData.Component.Constant
{
    public class IFareDataConstant : Constant
    {
        // iFareData.ini [CONNECT]
        public static readonly int FRSRQ_RETRY = 2;
        public static readonly int FRSRQ_WAIT = 5;
        public static readonly int ERRORLOG_DELETE = 30;
        public static readonly string CONFIG_FILE_NAME = "iFareData.ini";

        // SwsURL.ini [URL]
        public static readonly string URL_SWS_CERT = @"https://webservices.cert.platform.sabre.com";
        public static readonly string CONTRACT_VERSION = "5.7.1";
        public static readonly string STATUSRQ_VERSION = "5.2.0";
        public static readonly string SWS_URL_FILE_NAME = "SwsURL.ini";

    }
}
