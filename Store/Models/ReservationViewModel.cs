using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Entities.ReservationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ReservationViewModel
    {
        public Reservation Reservation { get; set; }
        public Phone Phone { get; set; }
        public List<OrderItem> OrderItem { get; set; }
        public int Quantity { get; set; }
    }
}
