using Microsoft.EntityFrameworkCore;
using Store.Data.Entities.ReservationAggregate;
using Store.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.EF.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly PhonesContext _context;

        public ReservationRepository(PhonesContext context)
        {
            _context = context;
        }

        public Reservation Get(int id)
        {
            return _context.Reservations.Include(b => b.ReservedItem).Where(x => x.Id == id).FirstOrDefault();
        }
        public List<Reservation> GetAll()
        {
            return _context.Reservations.Include(b => b.ReservedItem).ToList();
        }
        public void Create(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        public void Update(Reservation reservation)
        {
            _context.Reservations.Attach(reservation);
            _context.Entry(reservation).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(Reservation reservation)
        {
            _context.Reservations.Attach(reservation);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
