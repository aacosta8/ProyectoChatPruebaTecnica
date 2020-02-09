﻿using System.Web.Http;

namespace ChatPruebaTecnica.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Entities;
    using Models.ViewModels;

    public class UserController : ApiController
    {
        [HttpGet]
        public Reply Get()
        {
            Reply reply = new Reply();
            using (ChatPruebaTecnicaDBEntities db = new ChatPruebaTecnicaDBEntities())
            {
                List<UserViewModel> lista = (from user in db.Users 
                                            select new UserViewModel
                                            {
                                                NickName = user.nickName

                                            }).ToList();
                reply.Data = lista;
                reply.Result = 1;
            }

            return reply;
        }

        [HttpPost]
        public Reply Register([FromBody] Models.Requests.User user)
        {
            Reply reply = new Reply();
            try
            {
                using (ChatPruebaTecnicaDBEntities db = new ChatPruebaTecnicaDBEntities())
                {
                    Models.User modelUser = new User
                    {
                        nickName = user.NickName,
                        date_created = DateTime.Now,
                        idState = 1
                    };

                    db.Users.Add(modelUser);
                    reply.Result = db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                reply.Result = 0;
                reply.Message = "Intentalo más tarde.";
                reply.Data = e.InnerException;
            }
            
            return reply;
        }
    }
}