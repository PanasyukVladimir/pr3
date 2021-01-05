using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Repositories;
using Store.Domain.DTO;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Domain.DefaultImplementations
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IReservationRepository _resRepo;
        private IPhoneRepository _phoneRepository;
        private IPriceCalculationStrategy _priceStr;

        public OrderService(IOrderRepository orderRepository, IReservationRepository resRepo,
            IPhoneRepository phoneRepository, IPriceCalculationStrategy priceCalculationStrategy)
        {
            _orderRepository = orderRepository;
            _resRepo = resRepo;
            _phoneRepository = phoneRepository;
            _priceStr = priceCalculationStrategy;
        }


        public Order CreateOrder(OrderParametersDTO parametersDTO)
        {
            var res = _resRepo.Get(parametersDTO.ReservationId);

            if (res.OrderId != null)
            {
                throw new InvalidOperationException("Phone has been already issued to this reservation, unable to create another one");
            }

            var phone = _phoneRepository.GetPhone(res.ReservedItem.PhoneId);

            var newOrder = new Order()
            {
                ReservationId = res.Id,
                OrderDate = DateTime.Now,
                Name = parametersDTO.Name,
                Address = parametersDTO.Address,
                Email = parametersDTO.Email,
                City = parametersDTO.City,
                Status = OrderStatusEnum.Active,
                OrderItems = new List<OrderItem>()
            };

            var parametrs = new OrderParametersDTO();
            parametrs.Phone = phone;
            parametrs.Quantity = parametersDTO.Quantity;
            parametrs.Order = newOrder;

            newOrder.OrderItems = _priceStr.CalculatePrice(parametrs);

            _phoneRepository.DeletePhoneAmount(phone.Id, parametersDTO.Quantity);          

            res.OrderId = newOrder.Id;
            _resRepo.Update(res);

            _orderRepository.Create(newOrder);
            return newOrder;
        }
    }
}
