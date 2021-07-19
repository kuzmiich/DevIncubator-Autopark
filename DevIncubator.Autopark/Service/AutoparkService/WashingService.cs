using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class;
using DevIncubator.Autopark.Entity.Class.MyCollections;

namespace DevIncubator.Autopark.Service.AutoparkService
{
    internal class WashingService : IService
    {
        private readonly Collections _collections;

        public WashingService(Collections collections)
        {
            _collections = collections;
        }

        public void RunService()
        {
            
            var vehicles = _collections.Vehicles;
            var queue = new MyQueue<Vehicle>(vehicles.Count);

            Console.WriteLine("Queue:");
            foreach (var vehicle in vehicles)
            {
                queue.Enqueue(vehicle);
                Console.WriteLine($"Automobile {vehicle.ModelName} in queue");
            }

            Console.WriteLine("Washed vehicles:");
            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                var vehicle = queue.Dequeue();
                Console.WriteLine($"Automobile {vehicle.ModelName} washed");
            }
        }
    }
}
