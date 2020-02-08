namespace ChatWebPruebaTecnica.Business
{
    using System.Configuration;

    public class AppSettings
    {
        public static string UrlApi => ConfigurationManager.AppSettings["UrlApi"];

        public class Url
        {
            public static string REGISTER => UrlApi + "api/User/";
        }
    }
}