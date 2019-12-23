using ApartmentRentalService.Data.Entity;
using ApartmentRentalService.Data.Repositories;
using ApartmentRentalService.Domain.Interfaces;
using ApartmentRentalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmentRentalService.Controllers
{
    public class TenantController : Controller
    {
        private static Tenant _tenant;

        private IPriceCalculationStrategy priceCalculationStrategy;

        private IApartmentRepository apartmentRepository;
        private IReservationService reservationService;
        private IReservationRepository reservationRepository;
        private ITenantRepository tenantRepository;
        private IHomeownerRepository homeownerRepository;
        public TenantController(
            IReservationService reservationService,
            IReservationRepository reservationRepository,
            ITenantRepository tenantRepository,
            IApartmentRepository apartmentRepository,
            IHomeownerRepository homeownerRepository,
            IPriceCalculationStrategy priceCalculationStrategy)
        {
            this.reservationService = reservationService;
            this.reservationRepository = reservationRepository;
            this.tenantRepository = tenantRepository;
            this.apartmentRepository = apartmentRepository;
            this.homeownerRepository = homeownerRepository;
            this.priceCalculationStrategy = priceCalculationStrategy;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string phoneNumber)
        {
            var tenant = tenantRepository.GetTenants().FirstOrDefault(t => t.PhoneNumber == phoneNumber);
            if(tenant != null)
            {
                _tenant = tenant;
                return RedirectToAction("Apartments");
            }
            _tenant = new Tenant { PhoneNumber = phoneNumber };
            return RedirectToAction("RegisterTenant");
        }

        public ActionResult Apartments()
        {
            var apartments = apartmentRepository.GetAppartments();
            var model = new List<ApartmentViewModel>();

            foreach(var apartment in apartments)
            {
                var homeowner = homeownerRepository.Get(apartment.HomeownerId);
                model.Add(
                    new ApartmentViewModel
                    {
                        ApartmentId = apartment.Id,
                        Area = apartment.Area,
                        RoomsCount = apartment.RoomsCount,
                        Description = apartment.Description,
                        MonthlyFee = priceCalculationStrategy.Calculate(apartment.MonthlyFee, _tenant.Id),
                        HomeownerName = homeowner.Name,
                        HomeownerSurname = homeowner.Surname,
                        HomeownerPhoneNumber = homeowner.PhoneNumber
                    });
            }
            return View(model);
        }

        public ActionResult RegisterTenant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterTenant(string name, string surname)
        {
            _tenant.Name = name;
            _tenant.Surname = surname;
            tenantRepository.Create(_tenant);
            return RedirectToAction("Apartments");
        }

        public ActionResult Reserve(int apartmentId)
        {
            var model = new ReserveViewModel
            {
                ApartmentId = apartmentId,
                ReservedTimes = reservationService.GetReservedTimes(apartmentId, DateTime.Now, DateTime.Now.AddYears(1))
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Reserve(int apartmentId, DateTime startTime, DateTime endTime)
        {
            for (var dt = startTime; dt <= endTime; dt = dt.AddMonths(1))
            {
                var rt = new ReservationTime { Month = dt.Month, Year = dt.Year };
                if (reservationService.IsReserved(apartmentId, rt))
                {
                    return RedirectToAction("Error", new { message = "This period is reserved" });
                }
            }

            var resevation = new Reservation
            {
                AppartmentId = apartmentId,
                StartTime = new ReservationTime { Month = startTime.Month, Year = startTime.Year },
                EndTime = new ReservationTime { Month = endTime.Month, Year = endTime.Year },
                TenantId = _tenant.Id
            };
            var reservation = reservationService.Create(resevation);
            return RedirectToAction("ReservationDetails", new { reservationId = reservation.Id });
        }

        public ActionResult ReservationDetails(int reservationId)
        {
            var reservation = reservationRepository.Get(reservationId);
            var tenant = tenantRepository.Get(reservation.TenantId);
            var model = new ReservationDetailsViewModel
            {
                startTime = reservation.StartTime,
                endTime = reservation.EndTime,
                TenantName = tenant.Name,
                TenantSurname = tenant.Surname
            };
            return View(model);
        }
    }
}