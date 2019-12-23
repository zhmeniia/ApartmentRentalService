using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentRentalService.Models
{
    public class ReserveViewModel
    {
        public int ApartmentId { get; set; }
        public List<ReservationTime> ReservedTimes{ get; set; }
    }
}