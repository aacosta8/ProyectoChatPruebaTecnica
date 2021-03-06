﻿namespace ChatWebPruebaTecnica.Business
{
    using System.Configuration;

    public class AppSettings
    {
        public static string UrlApi => ConfigurationManager.AppSettings["UrlApi"];

        public class Url
        {
            public static string MESSAGES => UrlApi + "api/Message";
            public static string REGISTER => UrlApi + "api/User/";
            public static string ROOMS => UrlApi + "api/Room/";
            public static string SignalRHub => UrlApi + "signalr/hubs";
            public static string SignalR => UrlApi + "signalr/";
        }
    }
}