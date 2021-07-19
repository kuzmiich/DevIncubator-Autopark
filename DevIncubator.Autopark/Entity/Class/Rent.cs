using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIncubator.Autopark.Entity.Class
{
    public class Rent
    {
        public Rent()
        {
            
        }

        public Rent(DateTime date, decimal rentCost)
        {
            Date = date;
            RentCost = rentCost;
        }
        
        public DateTime Date { get; set; }
        public decimal RentCost { get; set; }

        public override string ToString()
        {
            return $"{Date},{RentCost}";
        }
    }
}
