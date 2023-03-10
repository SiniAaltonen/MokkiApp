using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MokkiAppDbContext _context;
        public ReservationRepository(MokkiAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetReservationAsync(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<int> UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            return _context.SaveChangesAsync();
        }

        public Task<int> AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            return _context.SaveChangesAsync();
        }
        public Task<int> DeleteReservation(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            return _context.SaveChangesAsync();
        }

        public async Task<bool> ReservationExistsAsync(string reservationName)
        {
            var formattedName = reservationName.Trim().ToLower();
            return await _context.Reservations.AnyAsync(p => p.Name.Trim().ToLower() == formattedName);
        }
    }
}
