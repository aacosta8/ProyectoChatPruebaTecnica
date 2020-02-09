namespace ChatPruebaTecnica.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using UtilitiesChatPruebaTecnica.Models;

    public class MessageController : ApiController
    {
        [HttpPost]
        public Reply GetMessages([FromBody]MessageRequest request)
        {
            Reply reply = new Reply();
            List<MessageResponse> messages = new List<MessageResponse>();
            
            try
            {
                using (ChatPruebaTecnicaDBEntities db = new ChatPruebaTecnicaDBEntities())
                {
                    messages = (from d in db.Messages.ToList()
                                where d.idState == 1 && d.idRoom == request.IdRoom
                                orderby d.date_created descending
                                select new MessageResponse
                                {
                                    Message = d.text,
                                    Id = d.id,
                                    IdUser = d.idUser,
                                    NickName = d.User.nickName,
                                    DateCreated = d.date_created,
                                    TypeMessage = (
                                                 new Func<int>(
                                                     () =>
                                                     {
                                                         try
                                                         {
                                                             if (d.idUser == request.IdUser)
                                                                 return 1;
                                                             else
                                                                 return 2;
                                                         }
                                                         catch
                                                         {
                                                             return 2;
                                                         }
                                                     }
                                                     )()
                                    )
                                }).ToList();
                    reply.Result = 1;
                    reply.Data = messages;
                }
            }
            catch(Exception e)
            {
                reply.Result = 0;
                reply.Message = "Intentalo más tarde.";
                reply.Data = e.InnerException;
            }

            return reply;
        }
    }
}
