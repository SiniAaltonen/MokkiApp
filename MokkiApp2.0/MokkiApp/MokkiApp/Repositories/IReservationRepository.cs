using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllReservationsAsync();

        Task<Reservation> GetReservationAsync(int id);

        Task<int> UpdateReservation(Reservation reservation);

        Task<int> AddReservation(Reservation reservation);

        Task<int> DeleteReservation(Reservation reservation);

        Task<bool> ReservationExistsAsync(string reservationName);
    }
}
