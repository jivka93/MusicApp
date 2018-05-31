using Autofac;
using Autofac.Integration.WebApi;
using MusicApp.Infrastructure.AutofacModules;
using MusicApp.Services;
using MusicApp.Services.Contracts;
using System.Reflection;
using System.Web.Http;

namespace MusicApp.App_Start
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config) {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;";

            builder
                .Register<IArtistService>(x => new ArtistService(connectionString))
                .SingleInstance();


            builder.RegisterModule(new WebModule());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}