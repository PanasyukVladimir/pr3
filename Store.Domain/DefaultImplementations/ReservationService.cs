using Store.Data.Entities.OrderAggregate;
using Store.Data.Entities.PhoneAggregate;
using Store.Data.Entities.ReservationAggregate;
using Store.Data.Repositories;
using Store.Domain.DTO;
using Store.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.DefaultImplementations
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _reservationRepository;
        private IPhoneRepository _phoneRepository;
        public ReservationService(
            IReservationRepository reservationRepository,
            IPhoneRepository phoneRepository)
        {
            _reservationRepository = reservationRepository;
            _phoneRepository = phoneRepository;
        }

        public void ReservationChecker()
        {
            var reservation_list = _reservationRepository.GetAll();
            foreach (var reserv in reservation_list)
            {
                if (DateTime.Now > reserv.End && reserv.OrderId == null)
                {
                    RemoveReservation(reserv.Id);
                }
            }
        }
        public void RemoveReservation(int reservationId)
        {
            var reservation = _reservationRepository.Get(reservationId);

            _phoneRepository.AddPhoneAmount(reservation.ReservedItem.PhoneId, reservation.ReservedItem.ReservedQuantity);

            reservation.End = DateTime.Now;
            _reservationRepository.Remove(reservation);
        }
        public Reservation Reserve(int phoneId, int quantity)
        {
            ReservationChecker();
            if (quantity > _phoneRepository.GetPhone(phoneId).Amount && quantity < 0)
            {
                throw new NotImplementedException();
            }

            var createIt = new Reservation()
            {
                Start = DateTime.Now,
                End = DateTime.Now.AddMinutes(20),
                ReservedItem = new ReservedItem()
            };

            ReservedItem reservedItem = new ReservedItem()
            {
                PhoneId = phoneId,
                ReservedQuantity = quantity,
                Reservation = createIt,
                ReservationId = createIt.Id,
            };

            createIt.ReservedItem = reservedItem;
            _phoneRepository.DeletePhoneAmount(phoneId, quantity);

            _reservationRepository.Create(createIt);

            return createIt;
        }
    }
}
