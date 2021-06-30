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

        public virtual string Display() => $"Type Name - {TypeName}\nTax Coefficient - {TaxCoefficient}\n";

        public override string ToString() => $"Type Name - {TypeName}, Tax Coefficient - {TaxCoefficient}";
    }
}
