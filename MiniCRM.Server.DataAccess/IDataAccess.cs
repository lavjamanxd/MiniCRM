using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCRM.Shared;

namespace MiniCRM.Server.DataAccess

{
    public interface IDataAccess
    {
        Task<List<Appointment>> GetAppointments(int userId);
        Task Save(Appointment appointment);
    }
}
