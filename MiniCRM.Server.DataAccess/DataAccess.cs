using System.Collections.Generic;
using System.IO;
using MiniCRM.Shared;
using Newtonsoft.Json;
using System.Linq;

namespace MiniCRM.Server.DataAccess
{
    public class DataAccess : IDataAccess {
        private const string Path = @"c:\MiniCRM.json";

        public List<Appointment> GetAppointments(int userId)
        {
            return GetAppointments().Where(a => a.UserId == userId).ToList();
        }

        public void Save(Appointment appointment)
        {
            var appointments = GetAppointments();
            appointments.Add(appointment);
            var json = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            using (var sw = File.CreateText(Path))
            {
                sw.Write(json);
            }
        }

        private List<Appointment> GetAppointments()
        {
            if (!File.Exists(Path))
                return new List<Appointment>();
            var json = File.ReadAllText(Path);
            return JsonConvert.DeserializeObject<List<Appointment>>(json);
        }
    }
}
