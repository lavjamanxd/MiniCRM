using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniCRM.Shared;
using RestEase;

namespace MiniCRM.Core.ServerAccess
{
    public class MiniCrmBackend : IMiniCrmApi
    {
        private readonly IMiniCrmApi _miniCrmApi;

        public MiniCrmBackend()
        {
            _miniCrmApi = RestClient.For<IMiniCrmApi>("http://127.0.0.1:8080");
        }

        public Task<IEnumerable<Appointment>> GetAppointments(int userId, DateTime from, DateTime to)
        {
            return _miniCrmApi.GetAppointments(userId, from, to);
        }
    }
}