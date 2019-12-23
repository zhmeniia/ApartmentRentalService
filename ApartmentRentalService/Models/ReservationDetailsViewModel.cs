using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentRentalService.Models
{
    public class ReservationDetailsViewModel
    {
        public string TenantName { get; set; }
        public string TenantSurname { get; set; }
        public ReservationTime startTime{ get; set; }
        public ReservationTime endTime { get; set; }
    }
}