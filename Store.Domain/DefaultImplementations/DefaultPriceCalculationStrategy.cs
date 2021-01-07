using Store.Data.Entities.OrderAggregate;
using Store.Data.Repositories;
using Store.Domain.DTO;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.DefaultImplementations
{
    public class DefaultPriceCalculationStrategy : IPriceCalculationStrategy
    {
        private IPhoneRepository _phoneRepository;

        public DefaultPriceCalculationStrategy(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }


        public List<OrderItem> CalculatePrice(PriceStrategyParametersDTO parametrs)
        {
            var components = new List<OrderItem>();

            var phone = _phoneRepository.GetPhone(parametrs.PhoneId);

            var phoneComponent = new OrderItem();

            phoneComponent.Price = phone.Price * parametrs.Quantity;
            
            components.Add(phoneComponent);

            return components;
        }
    }
}
