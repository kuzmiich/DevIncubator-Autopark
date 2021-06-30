using System.ComponentModel.DataAnnotations;
using DevIncubator.Autopark.Entity.Enum;
using DevIncubator.Autopark.Entity.Interface;

namespace DevIncubator.Autopark.Entity.Class
{
    public class VehicleType
    {
        public VehicleType()
        {
        }

        public VehicleType(string typeName, decimal taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        #region Class Property

        public virtual string TypeName { get; set; }

        public virtual decimal TaxCoefficient { get; set; }

        #endregion

        public virtual string Display()
        {
            return $"Type Name - {TypeName}\n" +
                   $"Tax Coefficient - {TaxCoefficient}\n";
        }

        public override string ToString()
        {
            return $"Type Name - {TypeName}, Tax Coefficient - {TaxCoefficient}";
        }
    }
}
