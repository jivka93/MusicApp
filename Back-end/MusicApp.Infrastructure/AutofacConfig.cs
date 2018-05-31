using Autofac;
using MusicApp.Infrastructure.AutofacModules;

namespace MusicApp.Infrastructure
{
    public class AutofacConfig
    {
        public AutofacConfig()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ServicesModule());
            builder.RegisterModule(new WebModule());

            var container = builder.Build();
        }
    }
}
