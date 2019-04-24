using System;
using System.Collections.Generic;
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
