using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Repositories;
using Store.Domain.DTO;
using Store.Domain.Interfaces;
using Store.Models;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        private IPhoneRepository _phoneRepository;
        private IReservationRepository _reservationRepository;
        private IReservationService _reservationService;
        private IOrderService _orderService;
        private IOrderRepository _orderRepository;
        private IPriceCalculationStrategy _priceCalculationStrategy;

        public OrderController(IPhoneRepository phoneRepository,
            IReservationService resServ,
            IOrderService orderServ,
            IPriceCalculationStrategy priceCalcStrategy,
            IReservationRepository reservationRepo,
            IOrderRepository orderRepository)
        {
            _phoneRepository = phoneRepository;
            _reservationService = resServ;
            _orderService = orderServ;
            _priceCalculationStrategy = priceCalcStrategy;
            _reservationRepository = reservationRepo;
            _orderRepository = orderRepository;
        }


        public ActionResult ReservePhone(int phoneId, int quantity)
        {
            _reservationService.ReservationChecker();
            var phone = _phoneRepository.GetPhone(phoneId);

            if (phone.Amount < quantity || quantity <= 0)
            {
                return RedirectToAction("Eroor");
            }

            var parametrs = new PriceStrategyParametersDTO();
            parametrs.PhoneId = phoneId;
            parametrs.Quantity = quantity;

            var reservation = _reservationService.Reserve(phoneId, quantity);

            var model = new ReservationViewModel()
            {
                Reservation = reservation,
                Phone = phone,
                OrderItem = _priceCalculationStrategy.CalculatePrice(parametrs),
                Quantity = quantity
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(CreateOrderViewModel model)
        {
            _reservationService.ReservationChecker();
            var reservation = _reservationRepository.Get(model.ReservationId);

            var parametrs = new OrderParametersDTO();
            parametrs.Name = model.Name;
            parametrs.ReservationId = model.ReservationId;
            parametrs.Address = model.Address;
            parametrs.City = model.City;
            parametrs.Email = model.Email;
            parametrs.Quantity = reservation.ReservedItem.ReservedQuantity;

            var order = _orderService.CreateOrder(parametrs);

            return RedirectToAction("Phone", new { id = order.Id });
        }

        public ActionResult Phone(int id)
        {
            var order = _orderRepository.GetOrder(id);
            var reservation = _reservationRepository.Get(order.ReservationId);

            var phone = _phoneRepository.GetPhone(reservation.ReservedItem.PhoneId);

            var phoneWM = new PhoneViewModel();
            phoneWM.Name = phone.Name;
            phoneWM.Order = order;
            phoneWM.Model = phone.Model;
            phoneWM.Description = phone.Description;
            phoneWM.Price =  phone.Price;
            phoneWM.Amount = phone.Amount;

            return View(phoneWM);
        }
        public ActionResult Eroor()
        {
            return View();
        }
    }
}
