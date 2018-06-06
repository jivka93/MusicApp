using MusicApplication.App_Start;
using System.Web.Http;

namespace AutoFacWithWebAPI.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}