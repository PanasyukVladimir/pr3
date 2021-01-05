using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Repositories;
using Store.Domain.Interfaces;

namespace Store.Controllers
{
    public class PhoneController : Controller
    {
        private IPhoneRepository _phoneRepository;
        private IReservationService _reservationService;

        public PhoneController(IPhoneRepository phoneRepository, IReservationService reservationService)
        {
            _phoneRepository = phoneRepository;
            _reservationService = reservationService;
        }

        public IActionResult Index(int id)
        {
            var phone = _phoneRepository.GetPhone(id);
            _reservationService.ReservationChecker();

            return View(phone);
        }
    }
}
