using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIncubator.Autopark.Entity.Class.VehicleComponent.Base
{
    public class Engine
    {
        public Engine(string typeName, decimal taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }
        public string TypeName { get; }
        public decimal TaxCoefficient { get; set; }

        public override string ToString()
        {
            return $"Type name - {TypeName}, Tax Coefficient - {TaxCoefficient:0.00}";
        }
    }
}
