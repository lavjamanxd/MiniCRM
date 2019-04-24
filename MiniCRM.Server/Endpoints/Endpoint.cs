using System;
using System.IO;
using System.Threading.Tasks;
using MiniCRM.Shared;
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
            Get("getAppointments", GetAppointmentsFromBackend);
            Post("saveAppointment", SaveAppointment);
        }

        private Task<string> GetAppointmentsFromBackend(dynamic o)
        {
            var from = DateTime.Parse(Request.Query["from"]);
            var to = DateTime.Parse(Request.Query["to"]);
            var userId = Int32.Parse(Request.Query["userId"]);

            var result = _backend.GetAppointments(userId, from, to);

            var serializeObject = JsonConvert.SerializeObject(result);
            return Task.FromResult(serializeObject);
        }

        private Task<object> SaveAppointment(object arg)
        {
            var  reader = new StreamReader(Request.Body);
            var json = reader.ReadToEnd();

            var newAppointment = Appointment.Deserialize(json);
            _backend.SaveAppointment(newAppointment);
            return null;
        }
    }
}
