using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.Entity
{
    public class Reservation
    {
        public int Id { get; set; }
        public ReservationTime StartTime { get; set; }
        public ReservationTime EndTime { get; set; }
        public int TenantId { get; set; }
        public int AppartmentId { get; set; }

        public int? TenantStrarsCount { get; set; }
    }
}
