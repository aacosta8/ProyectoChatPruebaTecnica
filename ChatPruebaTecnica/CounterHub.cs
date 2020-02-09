namespace ChatPruebaTecnica
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;
    using Models;

    public class CounterHub : Hub
    {
        private static int amountUsersOnline = 0;

        public override Task OnConnected()
        {
            var message = "Ha ingresado un nuevo usuario a la sala.";
            amountUsersOnline++;
            Clients.All.enterUser(amountUsersOnline, message);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            amountUsersOnline--;
            var message = "Un usuario ha abandonado la sala.";
            Clients.All.enterUser(amountUsersOnline, message);
            return base.OnDisconnected(stopCalled);
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