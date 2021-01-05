using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Entities.OrderAggregate
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int PhoneId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
