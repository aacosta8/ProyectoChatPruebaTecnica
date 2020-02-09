namespace ChatWebPruebaTecnica.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Business;
    using Models.Requests;
    using Newtonsoft.Json;
    using UtilitiesChatPruebaTecnica.Models;
    using UtilitiesChatPruebaTecnica.Tools;

    public class LobbyController : Controller
    {
        public ActionResult Index()
        {
            RequestUtil request = new RequestUtil();
            
            List<Room> rooms = new List<Room>();

            Reply response = request.Execute<Reply>(AppSettings.Url.ROOMS, "get", null);
            
            rooms = JsonConvert.DeserializeObject<List<Room>>(JsonConvert.SerializeObject(response.Data));
            
            ViewBag.error = response.Message;

            return View(rooms);
        }
    }
}
