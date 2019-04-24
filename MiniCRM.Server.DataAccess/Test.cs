using System;
using System.IO;
using MiniCRM.Shared;

namespace MiniCRM.Server.DataAccess
{
    public class Test
    {
        static void Main()
        {
            File.Delete(@"c:\MiniCRM.json");

            var dataAccess = new DataAccess();

            var now = DateTime.Now;
            dataAccess.Save(new Appointment
            {
                UserId = 1,
                Keyword = "elso",
                StartTime = now,
                EndTime = now + TimeSpan.FromHours(1)
            });

            dataAccess.Save(new Appointment
            {
                UserId = 2,
                Keyword = "masodik",
                StartTime = now,
                EndTime = now + TimeSpan.FromHours(1)
            });

            var result = dataAccess.GetAppointments(1);

            Console.WriteLine(result.Count);

            var appointment = result[0];

            Console.WriteLine(appointment.UserId);
            Console.WriteLine(appointment.Keyword);
            Console.WriteLine(appointment.StartTime);
            Console.WriteLine(appointment.EndTime);

            result = dataAccess.GetAppointments(2);

            Console.WriteLine(result.Count);

            appointment = result[0];

            Console.WriteLine(appointment.UserId);
            Console.WriteLine(appointment.Keyword);
            Console.WriteLine(appointment.StartTime);
            Console.WriteLine(appointment.EndTime);

            Console.ReadKey();
        }
    }
}
