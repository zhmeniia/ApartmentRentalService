using ApartmentRentalService.Data.Repositories;
using ApartmentRentalService.Domain.Interfaces;
using ApartmentRentalService.Domain.Services;
using ApartmentRentalService.Domain.Strategies;
using ApartmentRentalService.EF.Repositories;
using Ninject.Modules;

namespace ApartmentRentalService
{
    internal class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IReservationRepository>().To<ReservationRepository>();
            Bind<ITenantRepository>().To<TenantRepository>();
            Bind<IApartmentRepository>().To<ApartmentRepository>();
            Bind<IHomeownerRepository>().To<HomeownerRepository>();

            Bind<IReservationService>().To<ReservationService>();
            Bind<IHomeownerService>().To<HomeownerService>();

            Bind<IPriceCalculationStrategy>().To<PriceCalculationStrategy>();
            Bind<IPremiumTenantCalculationStrategy>().To<PremiumTenantCalculationStrategy>();
        }
    }
}