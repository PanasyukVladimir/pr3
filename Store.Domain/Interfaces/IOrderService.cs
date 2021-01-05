using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(OrderParametersDTO parametersDTO);
    }
}
