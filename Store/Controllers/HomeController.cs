using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Data.Repositories;
using Store.Domain.Interfaces;
using Store.Models;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private IPhoneRepository _phoneRepository;
        private IReservationService _reservationService;
        public HomeController(IPhoneRepository phoneRepository, IReservationService reservationService)
        {
            _phoneRepository = phoneRepository;
            _reservationService = reservationService;
        }

        public ViewResult Index()
        {
            var phones = new PhoneListViewModel()
            {
                Phones = _phoneRepository.GetAllPhones()
            };
            _reservationService.ReservationChecker();

            return View(phones);
        }
    }
}
