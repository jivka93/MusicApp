using Autofac;
using Autofac.Integration.WebApi;
using MusicApplication.Services;
using MusicApplication.Services.contracts;
using System.Reflection;
using System.Web.Http;

namespace MusicApplication.App_Start
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog = MusicApp; Integrated Security = True;";

            builder
                .Register<IArtistService>(x => new ArtistService(connectionString))
                .SingleInstance();

            builder
                .Register<IAlbumService>(x => new AlbumService(connectionString))
                .SingleInstance();

            builder
                .Register<ISingleService>(x => new SingleService(connectionString))
                .SingleInstance();

            builder
                .Register<IUserService>(x => new UserService(connectionString))
                .SingleInstance();

            Container = builder.Build();

            return Container;
        }

    }
}