namespace ChatPruebaTecnica.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using UtilitiesChatPruebaTecnica.Models;

    public class RoomController : ApiController
    {
        [HttpGet]
        public Reply Get()
        {
            Reply reply = new Reply();
            try
            {
                using (ChatPruebaTecnicaDBEntities db = new ChatPruebaTecnicaDBEntities())
                {
                    List<Models.Requests.Room> rooms = (from d in db.Rooms
                                                where d.idState == 1
                                                select new Models.Requests.Room
                                                {
                                                    Id = d.id,
                                                    Name = d.name,
                                                    Description = d.description
                                                }).ToList();
                    reply.Result = 1;
                    reply.Data = rooms;
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

        [HttpPost]
        public Reply Save([FromBody] Models.Requests.Room room)
        {
            Reply reply = new Reply();
            try
            {
                using (ChatPruebaTecnicaDBEntities db = new ChatPruebaTecnicaDBEntities())
                {
                    Models.Room modelRoom = new Models.Room
                    {
                        name = room.Name,
                        description = room.Description,
                        date_created = DateTime.Now,
                        idState = 1
                    };

                    db.Rooms.Add(modelRoom);
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
