﻿namespace ChatWebPruebaTecnica.Controllers
{
    using System.Web.Mvc;
    using Business;
    using Models.Requests;
    using Models.ViewModels;
    using Newtonsoft.Json;
    using UtilitiesChatPruebaTecnica.Models;
    using UtilitiesChatPruebaTecnica.Tools;

    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        } 
        
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User
            {
                NickName = model.NickName
            };

            RequestUtil request = new RequestUtil();

            Reply response = request.Execute<User>(AppSettings.Url.REGISTER, "post", user);
            var userResponse = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(response.Data));

            if (response.Result == 1)
            {
                Session["User"] = userResponse;

                return RedirectToAction("Index", "Lobby");
            }

            ViewBag.error = response.Message;

            return View(model);
        }
    }
}