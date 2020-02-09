namespace ChatPruebaTecnica
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR;

    public class CounterHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.All.enterUser();
            return base.OnConnected();
        }

        public void Send(int idRoom, int idUser, string username, string message)
        {
            Clients.All.sendChat(username, message);
        }
    }
}