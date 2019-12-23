using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentRentalService.Models
{
    public class ApartmentViewModel
    {
        public int ApartmentId { get; set; }
        public int RoomsCount { get; set; }
        public double Area { get; set; }
        public string Description { get; set; }
        public decimal MonthlyFee { get; set; }
        public string HomeownerName { get; set; }
        public string HomeownerSurname { get; set; }
        public string HomeownerPhoneNumber { get; set; }
    }
}