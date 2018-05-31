using Autofac;
using MusicApp.Services;
using MusicApp.Services.Contracts;

namespace MusicApp.Infrastructure.AutofacModules
{
    public sealed class ServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;";

            builder.RegisterType<ArtistService>().As<IArtistService>().WithParameter("connectionString", connectionString);
        }
    }
}
