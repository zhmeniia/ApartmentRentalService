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
    public class HomeownerController : Controller
    {
        private static Homeowner _homeowner;


        private IApartmentRepository apartmentRepository;
        private IHomeownerRepository homeownerRepository;
        private IHomeownerService homeownerService;
        private ITenantRepository tenantRepository;
        public HomeownerController(
            IApartmentRepository apartmentRepository,
            IHomeownerRepository homeownerRepository,
            IHomeownerService homeownerService,
            ITenantRepository tenantRepository)
        {
            this.apartmentRepository = apartmentRepository;
            this.homeownerRepository = homeownerRepository;
            this.homeownerService = homeownerService;
            this.tenantRepository = tenantRepository;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string phoneNumber)
        {
            var homeowner = homeownerRepository.GetHomeowners().FirstOrDefault(h => h.PhoneNumber == phoneNumber);
            if (homeowner != null)
            {
                _homeowner = homeowner;
                return RedirectToAction("Apartments");
            }
            _homeowner = new Homeowner { PhoneNumber = phoneNumber };
            return RedirectToAction("RegisterHomeowner");
        }

        public ActionResult Apartments()
        {
            var apartments = apartmentRepository.GetAppartments().Where(a => a.HomeownerId == _homeowner.Id);
            var model = new List<ApartmentViewModel>();

            foreach (var apartment in apartments)
            {
                var homeowner = homeownerRepository.Get(apartment.HomeownerId);
                model.Add(
                    new ApartmentViewModel
                    {
                        ApartmentId = apartment.Id,
                        Area = apartment.Area,
                        RoomsCount = apartment.RoomsCount,
                        Description = apartment.Description,
                        MonthlyFee = apartment.MonthlyFee,
                        HomeownerName = homeowner.Name,
                        HomeownerSurname = homeowner.Surname,
                        HomeownerPhoneNumber = homeowner.PhoneNumber
                    });
            }
            return View(model);
        }

        public ActionResult RegisterHomeowner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterHomeowner(string name, string surname)
        {
            _homeowner.Name = name;
            _homeowner.Surname = surname;
            homeownerRepository.Create(_homeowner);
            return RedirectToAction("Apartments");
        }

        public ActionResult AddApartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddApartment(Apartment apartment)
        {
            apartment.HomeownerId = _homeowner.Id;
            apartmentRepository.Create(apartment);
            return RedirectToAction("Apartments");
        }

        public ActionResult RateTenants()
        {
            var reservations = homeownerService.GetNotRatedReservations(_homeowner.Id);
            var model = new List<RateTenantViewModel>();
            foreach(var reservation in reservations)
            {
                 var tenant = tenantRepository.Get(reservation.TenantId);
                model.Add(new RateTenantViewModel
                {
                    FirstName=tenant.Name, LastName=tenant.Surname, StartTime=reservation.StartTime, EndTime=reservation.EndTime
                });
            }
            return View(model);
        }


        public ActionResult RateTenant(int tenantId)
        {
            ViewBag.TenantId = tenantId;
            return View();
        }

        [HttpPost]
        public ActionResult RateTenant(int tenantId, int starsCount)
        {
           // homeownerService.RateTenant tenantId, starsCount);
            return RedirectToAction("Apartments");
        }
    }

     public class RateTenantViewModel { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ReservationTime StartTime { get; set; }
        public ReservationTime EndTime { get; set; }
    }


}