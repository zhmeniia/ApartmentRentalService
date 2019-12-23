using ApartmentRentalService.Data.Repositories;
using ApartmentRentalService.Domain.Interfaces;
using ApartmentRentalService.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Domain.Strategies
{
    public class PriceCalculationStrategy : IPriceCalculationStrategy
    {
        private ITenantRepository tenantRepository;
        public PriceCalculationStrategy(ITenantRepository tenantRepository)
        {
            this.tenantRepository = tenantRepository;
        }

        public decimal Calculate(decimal price, int tenantId)
        {
            var tenant = tenantRepository.Get(tenantId);
            if (tenant.IsPremiumTenant)
            {
                price = price * 0.95m;
            }
            return price;
        }
    }
}
