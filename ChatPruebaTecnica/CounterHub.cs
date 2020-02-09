namespace ChatPruebaTecnica
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using Models;

    public class CounterHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.All.enterUser();
            return base.OnConnected();
        }

        public void AddGroup(int idRoom)
        {
            Groups.Add(Context.ConnectionId, idRoom.ToString());
        }

        public void Send(int idRoom, int idUser, string userName, string message)
        {
            var date = DateTime.Now.ToString();
            using (ChatPruebaTecnicaDBEntities db = new ChatPruebaTecnicaDBEntities())
            {
                var oMessage = new Message();
                oMessage.idRoom = idRoom;
                oMessage.date_created = DateTime.Now;
                oMessage.idUser = idUser;
                oMessage.text = message;
                oMessage.idState = 1;

                db.Messages.Add(oMessage);
                db.SaveChanges();
            }
            Clients.Group(idRoom.ToString()).sendChat(userName, message, date, idUser);
        }
    }
}