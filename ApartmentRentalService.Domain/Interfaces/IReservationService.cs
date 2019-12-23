using ApartmentRentalService.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Domain.Interfaces
{
    public interface IReservationService
    {
        Reservation Create(Reservation reservation);
        bool IsReserved(int apartmentid, ReservationTime time);
        List<ReservationTime> GetReservedTimes(int apartmentid, DateTime startTime, DateTime endTime);
    }
}
