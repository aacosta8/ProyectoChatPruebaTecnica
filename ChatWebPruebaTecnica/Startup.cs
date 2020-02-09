using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatWebPruebaTecnica.Startup))]

namespace ChatWebPruebaTecnica
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
