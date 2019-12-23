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
    public class HomeController : Controller
    {
        
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}