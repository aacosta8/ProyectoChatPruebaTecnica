namespace UtilitiesChatPruebaTecnica.Tools
{
    using System;
    using System.IO;
    using System.Net;
    using System.Web.Script.Serialization;
    using Models;
    using Newtonsoft.Json;

    public class RequestUtil
    {
        public Reply Reply { get; set; }

        public RequestUtil()
        {
            this.Reply = new Reply();
        }

        public Reply Execute<T>(string url, string method, T objectRequest)
        {
            Reply.Result = 0;
            string result = "";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = JsonConvert.SerializeObject(objectRequest);

                WebRequest request = WebRequest.Create(url);
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = " application/json;charset=utf-8";
                request.Timeout = 60000;

                if (objectRequest != null)
                {
                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        streamWriter.Write(json);
                        streamWriter.Flush();
                    }
                }
                
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var oStreamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = oStreamReader.ReadToEnd();
                }

                Reply = JsonConvert.DeserializeObject<Reply>(result);

            }
            catch (TimeoutException e)
            {
                Reply.Message = "Servidor sin respuesta";
            }
            catch (Exception e)
            {
                Reply.Message = "Ocurrio un error";
            }

            return Reply;
        }
    }
}