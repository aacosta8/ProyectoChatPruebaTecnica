using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatPruebaTecnica.Startup))]

namespace ChatPruebaTecnica
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Cors;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration { };
                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
