using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.MyCollections;

namespace DevIncubator.Autopark.Service.AutoparkService
{
    internal class GarageService : IService
    {
        private readonly Collections _collections;

        public GarageService(Collections collections)
        {
            _collections = collections;
        }

        public void RunService()
        {
            var vehicles = _collections.Vehicles;
            var stack = new MyStack<Vehicle>(vehicles.Count);

            Console.WriteLine("Stack:");
            foreach (var vehicle in vehicles)
            {
                stack.Push(vehicle);
                Console.WriteLine($"Automobile {vehicle.ModelName} pulled into the garage");
            }

            Console.WriteLine("The garage is full...");

            var count = stack.Count;
            for (int i = 0; i < count; i++)
            {
                var vehicle = stack.Pop();
                Console.WriteLine($"Automobile {vehicle.ModelName} left the garage");
            }
        }
    }
}
