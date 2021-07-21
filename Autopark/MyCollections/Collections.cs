using Autopark.Extension;
using System;
using System.Collections.Generic;
using Autopark.Entity.Enums;
using Autopark.Engines;
using Autopark.Engines.Base;
using Autopark.Entity.Models;
using Autopark.OutputService;

namespace Autopark.MyCollections
{
    internal class Collections
	{
		public Collections(string vehiclesTypesPath, string vehiclesPath, string rentsPath)
		{
            ListVehicleTypes = LoadVehicleTypes($"{vehiclesTypesPath}");
			Vehicles = LoadVehicles($"{vehiclesPath}");
			LoadRents($"{rentsPath}");
		}

        public List<Vehicle> Vehicles { get; } = new();
        public List<VehicleType> ListVehicleTypes { get; } = new();

        private decimal SumTotalProfit => Vehicles.SumElement(vehicle => vehicle.GetTotalProfit);

        public void Insert(int index, Vehicle vehicle)
		{
			if (index < 0 || index > Vehicles.Count - 1)
			{
				Vehicles.Add(vehicle);
			}

			Vehicles.Insert(index, vehicle);
		}

		public int Delete(int index)
		{
			if (index < 0 || index > Vehicles.Count - 1)
			{
				return -1;
			}

			Vehicles.RemoveAt(index);
			return index;
		}

        public void Print()
		{
			Console.WriteLine($"{"ID",-5}{"Type",-10}{"Model name",-25}{"Number",-15}{"Weight(kg)",-15}" +
							  $"{"Year",-10}{"Mileage",-10}{"Color",-10}{"Income",-10}{"Tax",-10}{"Profit",-10}");
			foreach (var vehicle in Vehicles)
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

		public void Sort(IComparer<Vehicle> comparator) =>
			Vehicles.Sort(comparator);


        #region Load Vehicles

        private VehicleType SelectVehicleType(string sourceType)
        {
            if (sourceType is null)
            {
                throw new ArgumentNullException(nameof(sourceType));
            }
            foreach (var type in ListVehicleTypes)
            {
                if (type.Id.Equals(Convert.ToInt32(sourceType)))
                {
                    return type;
                }
            }

            return new VehicleType();
        }

        private Vehicle CreateVehicle(IReadOnlyList<string> csvData)
        {
            if (csvData is null)
            {
                throw new ArgumentNullException(nameof(csvData));
            }
            var id = Convert.ToInt32(csvData[0]);
            var type = SelectVehicleType(csvData[1]);
            var modelName = csvData[2];
            var registrationNumber = csvData[3];
            var weight = Convert.ToInt32(csvData[4]);
            var releaseYear = Convert.ToInt32(csvData[5]);
            var mileage = Convert.ToInt32(csvData[6]);
            var color = csvData[7].ToEnum<ColorType>().Value;

            AbstractEngine engine = csvData[8] switch
            {
                "Electrical" => new ElectricalEngine(Convert.ToDouble(csvData[10])),
                "Gasoline" => new GasolineEngine(Convert.ToDouble(csvData[9]), Convert.ToDouble(csvData[10])),
                "Diesel" => new DieselEngine(Convert.ToDouble(csvData[9]), Convert.ToDouble(csvData[10])),
                _ => null
            };

            var tankCapacity = Convert.ToDouble(csvData[^1]);

            return new Vehicle(id,
                type,
                engine,
                modelName,
                registrationNumber,
                weight,
                releaseYear,
                mileage,
                color,
                tankCapacity
                );
        }

        private List<Vehicle> LoadVehicles(string vehiclesPath)
        {
            var vehicles = new List<Vehicle>();
            var listVehiclesFields = new CsvFileReader(vehiclesPath).ReadLineCsvElements();
            foreach (var vehicleFields in listVehiclesFields)
            {
                vehicles.Add(CreateVehicle(vehicleFields));
            }

            return vehicles;
        }

        #endregion

        #region Load VehicleTypes

        private static VehicleType CreateVehicleType(int id, string typeName, decimal taxCoefficient) =>
            new(id, typeName, taxCoefficient);


        private static List<VehicleType> LoadVehicleTypes(string vehiclesTypesPath)
        {
            var listVehicleTypesFields = new CsvFileReader(vehiclesTypesPath).ReadLineCsvElements();
            var vehicleTypes = new List<VehicleType>();

            foreach (var vehicleTypeFields in listVehicleTypesFields)
            {
                var vehicleType = CreateVehicleType(Convert.ToInt32(vehicleTypeFields[0]),
                    vehicleTypeFields[1],
                    Convert.ToDecimal(vehicleTypeFields[2]));

                vehicleTypes.Add(vehicleType);
            }

            return vehicleTypes;
        }

        #endregion

        #region Load Rents

        private void CreateRents(IReadOnlyList<string> rentFields)
        {
            if (rentFields is null)
            {
                throw new ArgumentNullException(nameof(rentFields));
            }

            var vehicleId = Convert.ToInt32(rentFields[0]);
            var rentDate = Convert.ToDateTime(rentFields[1]);
            var rentCost = Convert.ToDecimal(rentFields[2]);

            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Id == vehicleId)
                {
                    vehicle.ListRent = new List<Rent>
                    {
                        new Rent(rentDate, rentCost)
                    };
                }
            }
        }

        private void LoadRents(string rentsPath)
        {
            var listRentsFields = new CsvFileReader(rentsPath).ReadLineCsvElements();
            
            foreach (var listRentFields in listRentsFields)
            {
                CreateRents(listRentFields);
            }
        }

        #endregion
    }
}
