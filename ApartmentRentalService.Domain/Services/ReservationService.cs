using ApartmentRentalService.Data.Entity;
using ApartmentRentalService.Data.Repositories;
using ApartmentRentalService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Domain.Services
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository reservationRepository;
        private ITenantRepository tenantRepository;
        public ReservationService(IReservationRepository reservationRepository, ITenantRepository tenantRepository)
        {
            this.reservationRepository = reservationRepository;
            this.tenantRepository = tenantRepository;
        }

        public Reservation Create(Reservation reservation)
        {
            reservationRepository.Create(reservation);
            return reservation;
        }

        public bool IsReserved(int id, ReservationTime time)
        {
            return reservationRepository.GetReservations()
                .Where(r => r.AppartmentId == id)
                .Any(r => r.StartTime <= time && r.EndTime >= time);
        }

        public List<ReservationTime> GetReservedTimes(int id, DateTime startTime, DateTime endTime)
        {
            var result = new List<ReservationTime>();
            while(startTime < endTime)
            {
                var rt = new ReservationTime { Month = startTime.Month, Year = startTime.Year };
                if(IsReserved(id, rt))
                {
                    result.Add(rt);
                }
                startTime = startTime.AddMonths(1);
            }
            return result;
        }
    }
}
