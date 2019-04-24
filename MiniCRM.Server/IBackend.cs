using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCRM.Shared;

namespace MiniCRM.Server
{
    public interface IBackend
    {
        void SaveAppointment(Appointment newAppointment);

        IEnumerable<Appointment> GetAppointments(
            int userId, DateTime startTime, DateTime endTime
        );
    }
}
