using System;
using System.Collections.Generic;
using MiniCRM.Shared;

namespace MiniCRM.Server
{
    public class Backend : IBackend
    {
        public void SaveAppointment(Appointment newAppointment)
        {

        }

        public IEnumerable<Appointment> GetAppointments(
            int userId, DateTime startTime, DateTime endTime
        )
        {
            return new List<Appointment>
            {
                new Appointment
                {
                    UserId = userId,
                    EndTime = endTime,
                    StartTime = startTime,
                    Keyword = "FromQuery"
                },
                new Appointment
                {
                    UserId = 2,
                    EndTime = new DateTime(2019, 10, 10),
                    StartTime = new DateTime(2009, 10, 10),
                    Keyword = "StaticDate"
                }
            };
        }
    }
}
