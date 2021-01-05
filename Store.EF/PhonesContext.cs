using Microsoft.EntityFrameworkCore;
using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Entities.ReservationAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.EF
{
    public class PhonesContext : DbContext
    {
        public PhonesContext()
        {
            Database.EnsureCreated();
        }
        public PhonesContext(DbContextOptions<PhonesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservedItem> ReservedItems { get; set; }   
    }
}
