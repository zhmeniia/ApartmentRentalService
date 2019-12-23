using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.Entity
{
    public class Apartment
    {
        public int Id { get; set; }
        public int RoomsCount { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
        public decimal MonthlyFee { get; set; }
        public int HomeownerId { get; set; }

    }
}
