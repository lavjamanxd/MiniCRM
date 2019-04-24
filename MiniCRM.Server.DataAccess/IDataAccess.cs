using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCRM.Shared;

namespace MiniCRM.Server.DataAccess

{
    public interface IDataAccess
    {
        List<Appointment> GetAppointments(int userId);
        void Save(Appointment appointment);
    }
}
