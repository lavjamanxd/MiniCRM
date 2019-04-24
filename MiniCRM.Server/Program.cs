using System;

namespace MiniCRM.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var webservice = new WebService();
            webservice.Start();
        }
    }
}
