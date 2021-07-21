using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Engines.Base
{
    public abstract class AbstractEngine
    {
        protected AbstractEngine(string typeName, decimal taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }
        public string TypeName { get; }
        public decimal TaxCoefficient { get; set; }

        public abstract double GetMaxKilometers(double fuelTank);
    }
}
