namespace ChatWebPruebaTecnica.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Business;
    using Newtonsoft.Json;
    using UtilitiesChatPruebaTecnica.Models;
    using UtilitiesChatPruebaTecnica.Tools;

    public class ChatController : Controller
    {
        public ActionResult Messages(int id, int? idUser)
        {

            List<MessageResponse> messages = new List<MessageResponse>();

            MessageRequest messageRequest = new MessageRequest();
            messageRequest.IdRoom = id;
            messageRequest.IdUser = idUser ?? 0;

            RequestUtil request = new RequestUtil();
            Reply reply = request.Execute<MessageRequest>(AppSettings.Url.MESSAGES, "post", messageRequest);

            messages = JsonConvert.DeserializeObject<List<MessageResponse>>(JsonConvert.SerializeObject(reply.Data));

            messages = messages.OrderBy(d => d.DateCreated).ToList();

            ViewBag.idRoom = id;

            return View(messages);

        }
    }
}
