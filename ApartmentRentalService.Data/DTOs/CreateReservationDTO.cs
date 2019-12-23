using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Data.DTOs
{
    public class CreateReservationDTO
    {
        public int AppartmentId { get; set; }
        public string TenantName { get; set; }
        public string TenantSurname { get; set; }
        public ReservationTime startTime{ get; set; }
        public ReservationTime endTime { get; set; }
    }
}
