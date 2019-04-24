using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCRM.Shared;
using RestEase;

namespace MiniCRM.Core.ServerAccess
{
    public interface IMiniCrmApi
    {
        [Get("getAppointments")]
        Task<IEnumerable<Appointment>> GetAppointments([Query] int userId, [Query] DateTime from, [Query] DateTime to);
    }
}
