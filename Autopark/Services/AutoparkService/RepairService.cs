using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Autopark.MyCollections;
using Autopark.OutputService;

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

            var values = new HashSet<string>();
            foreach (var detail in listDetails)
            {
                values.Add(detail);
            }

            var keys = new List<int>();
            foreach (var value in values)
            {
                var count = 0;
                foreach (var detail in listDetails)
                {
                    if (value.Equals(detail))
                    {
                        count++;
                    }
                }
                keys.Add(count);
            }

            var i = 0;
            var orders = new Dictionary<string, int>();
            foreach (var value in values)
            {
                orders.Add(value, keys[i]);
                i++;
            }
            Print(orders);
        }
    }
}

// aces47 realization
//
/*var _orders = new Dictionary<string, int>();
foreach (var detail in listDetails)
{
    if (!_orders.TryAdd(detail, 1))
    {
        _orders[detail]++;
    }
}*/