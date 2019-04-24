using System;

namespace MiniCRM.Shared
{
    public class Appointment
    {
        public string Keyword { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
