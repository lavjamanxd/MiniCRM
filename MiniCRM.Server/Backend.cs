using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCRM.Server.DataAccess;
using MiniCRM.Shared;

namespace MiniCRM.Server
{
    public class Backend : IBackend
    {
        public IDataAccess DataAccess = new DataAccess.DataAccess();

        public void SaveAppointment(Appointment newAppointment)
        {
            DataAccess.Save(newAppointment);
        }

        public  IEnumerable<Appointment> GetAppointments(
            int userId, DateTime startTime, DateTime endTime
        )
        {
            var appointments = DataAccess.GetAppointments(userId);

            foreach (var appointment in appointments)
            {
                if (
                    IsAppointmentInInterval(startTime, endTime, appointment)
                )
                   yield return appointment;
            }
        }

        private bool IsAppointmentInInterval(DateTime startTime, DateTime endTime, Appointment appointment)
        {
            return (appointment.StartTime <= startTime && appointment.EndTime > endTime)
                   || (appointment.StartTime <= startTime && appointment.EndTime > startTime)
                   || (appointment.StartTime >= startTime && appointment.StartTime < endTime)
                   || (appointment.StartTime >= startTime && appointment.EndTime < endTime);
        }
    }
}
