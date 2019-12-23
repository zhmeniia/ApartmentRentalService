using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Domain.Interfaces
{
    public interface IHomeownerService
    {
        List<Reservation> GetNotRatedReservations(int homeownerId);
        // Get Not Rated reservations return List<Reservation>
        void RateTenant( int reservationId, int starsCount); // RateTenant(int homeownerId, int reservationId, int starsCount)
    }
}
