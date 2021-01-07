using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.DTO
{
    public class OrderParametersDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ReservationId { get; set; }
        public int Quantity { get; set; }
    }
}
