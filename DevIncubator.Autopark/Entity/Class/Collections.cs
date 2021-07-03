using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines;
using DevIncubator.Autopark.Entity.Class.VehicleComponent.Engines.Base;
using DevIncubator.Autopark.Entity.Enum;
using DevIncubator.Autopark.Extension;
using DevIncubator.Autopark.OutputService;

namespace DevIncubator.Autopark.Entity.Class
{
    internal class Collections
    {
        public Collections(string vehiclesTypesPath, string vehiclesPath, string rentsPath)
        {
            ListVehicles = LoadVehicles(vehiclesPath);
            ListVehicleTypes = LoadVehicleTypes(vehiclesTypesPath);
            LoadRents(rentsPath);
        }

        public List<Vehicle> ListVehicles { get; }
        public List<VehicleType> ListVehicleTypes { get; }

        private Vehicle CreateVehicle(string[] csvData)
        {
            if (csvData == null)
            {
                throw new ArgumentNullException(nameof(csvData));
            }

            var id = Convert.ToInt32(csvData[0]);
            var modelName = csvData[3];
            var gosNumber = csvData[4];
            var weight = Convert.ToInt32(csvData[5]);
            var ManufactureYear = Convert.ToInt32(csvData[6]);
            var mileage = Convert.ToInt32(csvData[7]);
            var tankCapacity = Convert.ToDouble(csvData[^1]);

            var vehicleColor = ToEnum<ColorType>(csvData[8]);

            AbstractEngine engine = csvData[2] switch
            {
                "Electrical" => new ElectricalEngine(Convert.ToDouble(csvData[10])),
                "Gasoline" => new GasolineEngine(Convert.ToDouble(csvData[9]), Convert.ToDouble(csvData[10])),
                "Diesel" => new DieselEngine(Convert.ToDouble(csvData[9]), Convert.ToDouble(csvData[10])),
                _ => null
            };
            
            VehicleType vehicleType = null;
            foreach (var type in ListVehicleTypes)
            {
                if (type.Id.Equals(Convert.ToInt32(csvData[1])))
                {
                    vehicleType = type;
                    break;
                }
            }

            return new Vehicle();
        }

        public VehicleType CreateType(string csvString) => new VehicleType();
        
        public static T ToEnum<T>(string value)
        {
            return (T)System.Enum.Parse(typeof(T), value, true);
        }

        public void Insert(int index, Vehicle vehicle)
        {
            if (index < 0 || index > ListVehicles.Count - 1)
            {
                ListVehicles.Add(vehicle);
            }

            ListVehicles.Insert(index, vehicle);
        }

        public int Delete(int index)
        {
            if (index < 0 || index > ListVehicles.Count - 1)
            {
                return -1;
            }

            ListVehicles.RemoveAt(index);
            return index;
        }

        private decimal SumTotalProfit => ListVehicles.SumElement(vehicle => vehicle.GetTotalProfit);

        public void Print()
        {
            Console.WriteLine($"{"ID",-5}{"Type",-10}{"Model name",-25}{"Number",-15}{"Weight(kg)",-15}" +
                              $"{"Year",-10}{"Mileage",-10}{"Color",-10}{"Income",-10}{"Tax",-10}{"Profit",-10}");
            foreach (var vehicle in ListVehicles)
            {
                Console.WriteLine($"{vehicle.Id,-5}" +
                                  $"{vehicle.VehicleType.TypeName,-10}" +
                                  $"{vehicle.ModelName,-25}" +
                                  $"{vehicle.RegistrationNumber,-15}" +
                                  $"{vehicle.Weight,-15}" +
                                  $"{vehicle.ReleaseYear,-10}" +
                                  $"{vehicle.Mileage,-10}" +
                                  $"{vehicle.ColorType,-10}" +
                                  $"{vehicle.GetTotalIncome,-10:0.00}" +
                                  $"{vehicle.GetCalcTaxPerMonth,-10:0.00}" +
                                  $"{vehicle.GetTotalProfit,-10:0.00}");
            }
            Console.WriteLine($"Total: {SumTotalProfit,120:0.00}");
        }

        public void Sort(IComparer<Vehicle> comparator)
        {
            ListVehicles.Sort(comparator);
        }

        private static List<VehicleType> LoadVehicleTypes(string vehiclesTypesPath)
        {
            return new CsvFileReader(vehiclesTypesPath).ReadVehicleTypes();
        }

        private static List<Vehicle> LoadVehicles(string vehiclesPath)
        {
            return new CsvFileReader(vehiclesPath).ReadVehicles();
        }

        private static void LoadRents(string rentsPath)
        {
            new CsvFileReader(rentsPath).ReadRents();
        }
    }
}
