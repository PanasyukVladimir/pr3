using Microsoft.EntityFrameworkCore;
using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.EF.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PhonesContext _context;
        public OrderRepository(PhonesContext context)
        {
            _context = context;
        }

        public Order GetOrder(int orderId)
        {
            return _context.Orders.Include("OrderItems").Where(r => r.Id == orderId).Single();
        }
        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }  
}
