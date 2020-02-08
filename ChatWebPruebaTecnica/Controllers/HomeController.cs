namespace ChatWebPruebaTecnica.Controllers
{
    using System.Web.Mvc;
    using Business;
    using Models.Requests;
    using UtilitiesChatPruebaTecnica.Tools;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            User user = new User
            {
                NickName = "Alex Acosta Web"
            };

            RequestUtil request = new RequestUtil();

            request.Execute<User>(AppSettings.Url.REGISTER, "post", user);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}