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
    }
}