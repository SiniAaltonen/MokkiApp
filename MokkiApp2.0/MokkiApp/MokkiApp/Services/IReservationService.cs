using MokkiApp.Models;

namespace MokkiApp.Services
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservationsAsync();

        Task<Reservation> GetReservationAsync(int id);

        Task<Reservation> UpdateReservation(int id, Reservation reservation);

        Task<Reservation> AddReservation(Reservation reservation);

        Task<int> DeleteReservation(int id);
    }
}
