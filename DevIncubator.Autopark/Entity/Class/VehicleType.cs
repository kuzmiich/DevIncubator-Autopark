namespace DevIncubator.Autopark.Entity.Class
{
    public class VehicleType
    {
        public VehicleType()
        {
        }

        public VehicleType(int id, string typeName, decimal taxCoefficient)
        {
            Id = id;
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        #region Class Property

        public int Id { get; set; }

        public string TypeName { get; }

        public decimal TaxCoefficient { get; init; }

        #endregion

        public string Display() => $"Type Name - {TypeName}\nTax Coefficient - {TaxCoefficient}\n";

        public override string ToString() => $"{Id},{TypeName},{TaxCoefficient}";
    }
}
