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

        public string TypeName { get; }

        public virtual decimal TaxCoefficient { get; set; }

        #endregion

<<<<<<< HEAD
        public virtual string Display() => $"Type Name - {TypeName}\nTax Coefficient - {TaxCoefficient:0.00}\n";

        public override string ToString() => $"Type Name - {TypeName}, Tax Coefficient - {TaxCoefficient:0.00}";
        
=======
        public virtual string Display() => $"Type Name - {TypeName}\nTax Coefficient - {TaxCoefficient}\n";

        public override string ToString() => $"Type Name - {TypeName}, Tax Coefficient - {TaxCoefficient}";
>>>>>>> master
    }
}
