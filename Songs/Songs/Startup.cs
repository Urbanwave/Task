using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Songs.Startup))]
namespace Songs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}