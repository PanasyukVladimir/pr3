using Store.Data.Entities.OrderAggregate;
using Store.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Interfaces
{
    public interface IPriceCalculationStrategy
    {
        List<OrderItem> CalculatePrice(OrderParametersDTO parametrs);
    }
}
