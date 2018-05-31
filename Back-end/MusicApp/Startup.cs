using Microsoft.Owin;
using MusicApp.Infrastructure;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicApp.Startup))]
namespace MusicApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var autofacConfig = new AutofacConfig();
            ConfigureAuth(app);
        }
    }
}
