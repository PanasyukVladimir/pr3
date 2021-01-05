using Store.Data.Entities.ReservationAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.Repositories
{
    public interface IReservationRepository
    {
        void Create(Reservation reservation);
        void Update(Reservation reservation);
        void Remove(Reservation reservation);
        Reservation Get(int id);
        List<Reservation> GetAll();
    }
}
