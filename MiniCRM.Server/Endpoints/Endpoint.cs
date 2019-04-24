using Nancy;

namespace MiniCRM.Server.Endpoints
{
    public class EndpointModule : NancyModule
    {
        public EndpointModule()
        {
            Get("/test/{input}", Test);
        }

        private string Test(dynamic parameter)
        {
            return parameter.input.ToString();
        }
    }
}
