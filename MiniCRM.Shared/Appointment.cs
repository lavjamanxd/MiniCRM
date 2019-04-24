using System;
using Newtonsoft.Json;

namespace MiniCRM.Shared
{
    public class Appointment
    {
        public string Keyword { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public static Appointment Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Appointment>(json);
        }

        public static string Serialize(Appointment appintment)
        {
            return JsonConvert.SerializeObject(appintment);
        }
    }
}
