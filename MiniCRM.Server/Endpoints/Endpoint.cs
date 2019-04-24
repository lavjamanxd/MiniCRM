using System;
using System.Threading.Tasks;
using Nancy;
using Newtonsoft.Json;

namespace MiniCRM.Server.Endpoints
{
    public class EndpointModule : NancyModule
    {
        private readonly IBackend _backend;

        public EndpointModule(IBackend backend)
        {
            _backend = backend;
            RegisterCalls();
        }

        private void RegisterCalls()
        {
            Get("getAppointments", Action);
            Post("saveAppointment", Action);
        }

        private Task<string> Action(dynamic o)
        {
            var from = DateTime.Parse(Request.Query["from"]);
            var to = DateTime.Parse(Request.Query["to"]);
            var userId = Int32.Parse(Request.Query["userId"]);

            var result = _backend.GetAppointments(userId, from, to);

            var serializeObject = JsonConvert.SerializeObject(result);
            return Task.FromResult(serializeObject);
        }
    }
}
