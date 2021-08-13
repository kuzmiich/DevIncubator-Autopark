using System;
using System.Collections.Generic;

namespace Autopark.Services.AutoparkService
{
    internal class RepairService : IService
    {
        private readonly List<List<string>> _listOrders;

        public RepairService(List<List<string>> listOrders)
    {
            _listOrders = listOrders;
        }

        private static void Print(Dictionary<string, int> items)
        {
            foreach (var (key, value) in items)
            {
                Console.WriteLine($"{key} - {value} шт.");
            }
        }
        public void RunService()
        {
            var listDetails = new List<string>();
            foreach (var details in _listOrders)
            {
                foreach (var detail in details)
                {
                    listDetails.Add(detail);
                }
            }
            
            var orders = new Dictionary<string, int>();
            foreach (var detail in listDetails)
            {
                if (!orders.TryAdd(detail, 1))
                {
                    orders[detail]++;
                }
            }
            Print(orders);
        }
    }
}