using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.Data.Entities.OrderAggregate
{
    public enum OrderStatusEnum { Active = 1, Sold = 2 }
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public OrderStatusEnum Status { get; set; }
        public DateTime OrderDate { get; set; }
        public int ReservationId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
