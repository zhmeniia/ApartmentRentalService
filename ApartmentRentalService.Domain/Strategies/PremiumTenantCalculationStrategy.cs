using ApartmentRentalService.Data.Repositories;
using ApartmentRentalService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Domain.Strategies
{
    public class PremiumTenantCalculationStrategy : IPremiumTenantCalculationStrategy
    {
        private IReservationRepository reservationRepository;

        public PremiumTenantCalculationStrategy(IReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        public bool IsPremium(int tenantId)
        {

            List<int?> stars = reservationRepository.GetReservations()
                  .Where(r => r.TenantId == tenantId)
                  .Select(r => r.TenantStrarsCount).ToList();
            var starsCount = stars.Where(s => s.HasValue && s.Value == 5).Count();
            if (starsCount > 4)
            {
                return true;
            }
            return false;
        }
    }
}
