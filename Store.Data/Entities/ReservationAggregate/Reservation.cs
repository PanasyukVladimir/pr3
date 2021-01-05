using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Entities.ReservationAggregate
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public ReservedItem ReservedItem { get; set; }
        public int? OrderId { get; set; }
    }
}
