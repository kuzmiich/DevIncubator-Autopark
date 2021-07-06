using DevIncubator.Autopark.Service;
using DevIncubator.Autopark.Service.AutoparkService;
using System;

namespace DevIncubator.Autopark
{
    class Program
    {
        static void Main(string[] args)
        {
            IService[] services =
            {
                new AutoparkInfoService(),
                new WashingService(),
                new GarageService(),
                new RepairService()
            };

            try
            {
                foreach (var service in services)
                {
                    service.RunService();
                    Console.WriteLine(string.Empty.PadLeft(120, '-'));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}