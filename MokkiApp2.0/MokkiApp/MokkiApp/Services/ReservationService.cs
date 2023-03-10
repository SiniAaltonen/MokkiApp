using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;

namespace MokkiApp.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllReservationsAsync();
        }
        public async Task<Reservation> GetReservationAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationAsync(id);
            return reservation;
        }

        public async Task<Reservation> UpdateReservation(int id, Reservation reservation)
        {
            var reservations = await _reservationRepository.GetAllReservationsAsync();
            var theReservation = await _reservationRepository.GetReservationAsync(id);

            if (reservation != null)
            {

                if (reservations.Count(p => p.Name == reservation.Name) > 1) throw new ArgumentException(nameof(reservation.Name));
                await _reservationRepository.UpdateReservation(theReservation);
                return theReservation;
            }
            throw new ArgumentException(nameof(id));
        }
        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            var theReservation = await _reservationRepository.GetAllReservationsAsync();
            if (!await _reservationRepository.ReservationExistsAsync(reservation.Name))
            {
                Reservation reservation1 = new Reservation();
                reservation.Name = reservation1.Name;
                reservation.Interests = reservation1.Interests;

                await _reservationRepository.AddReservation(reservation1);

                return reservation1;
            }
            throw new Exception("Reservation exists");
        }

        public async Task<int> DeleteReservation(int id)
        {

            var reservation = await _reservationRepository.GetReservationAsync(id);
            if (reservation != null)
            {
                _reservationRepository.DeleteReservation(reservation);
            }
            return id;
        }
    }
}
