using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Entities.ReservationAggregate;
using Store.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Interfaces
{
    public interface IReservationService
    {
        Reservation Reserve(int phoneId, int quantity);
        void RemoveReservation(int reservation);
        void ReservationChecker();
    }
}
