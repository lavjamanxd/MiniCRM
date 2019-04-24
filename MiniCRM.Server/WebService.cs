using Nancy.Owin;
using Suave;

namespace MiniCRM.Server
{
    public class WebService
    {
        public void Start()
        {
            var opts = new NancyOptions();
            var app = Owin.OwinAppModule.OfMidFunc("/", NancyMiddleware.UseNancy(opts));
            Web.startWebServer(Web.defaultConfig, app);
        }
    }
}
