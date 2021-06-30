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

        public virtual string Display()
        {
            return $"Type Name - {TypeName}\n" +
                   $"Tax Coefficient - {TaxCoefficient:0.00}\n";
        }

        public override string ToString()
        {
            return $"Type Name - {TypeName}, Tax Coefficient - {TaxCoefficient:0.00}";
        }
    }
}
