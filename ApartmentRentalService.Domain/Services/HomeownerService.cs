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
    public class HomeownerService : IHomeownerService
    {
        private IReservationRepository reservationRepository;
        private IApartmentRepository apartmentRepository;
        private ITenantRepository tenantRepository;
        private IPremiumTenantCalculationStrategy premiumTenantCalculationStrategy;
        public HomeownerService(
            IReservationRepository reservationRepository, 
            IApartmentRepository apartmentRepository,
            ITenantRepository tenantRepository,
            IPremiumTenantCalculationStrategy premiumTenantCalculationStrategy)
        {
            this.reservationRepository = reservationRepository;
            this.apartmentRepository = apartmentRepository;
            this.tenantRepository = tenantRepository;
            this.premiumTenantCalculationStrategy = premiumTenantCalculationStrategy;
        }

        public List<Reservation> GetNotRatedReservations(int homeownerId)
        {
            var tenants = new List<Tenant>();
            var homeownerApartmentsIds = apartmentRepository.GetAppartments()
                .Where(a => a.HomeownerId == homeownerId)
                .Select(a=>a.Id);
            var notReatedReservations = reservationRepository.GetReservations()
                .Where(r => homeownerApartmentsIds.Contains(r.AppartmentId))
                .Where(r=> !r.TenantStrarsCount.HasValue).ToList();


            return notReatedReservations;
        }

        public void RateTenant( int reservationId, int starsCount)
        {
            var reservation = reservationRepository.Get(reservationId);
            reservation.TenantStrarsCount = starsCount;
            reservationRepository.Update(reservation);
        }
    }
}
