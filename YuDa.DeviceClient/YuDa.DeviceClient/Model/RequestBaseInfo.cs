using System.Configuration;

namespace YuDa.DeviceClient
{
    public static class RequestBaseInfo
    {
        public static string ClientVersion = ConfigurationManager.AppSettings["ClientVersion"];
        public static string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
    }
}
