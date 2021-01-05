using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repositories
{
    public interface IOrderRepository
    {
        Order GetOrder(int orderId);
        void Create(Order order);
    }
}
