using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;

namespace MokkiApp.Repositories
{


    public class PlaceRepository : IPlaceRepository
    {
        private readonly MokkiAppDbContext _context;
        public PlaceRepository(MokkiAppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Place>> GetAllPlacesAsync()
        {
            return await _context.Places.ToListAsync();
        }
        public async Task<Place> GetPlaceAsync(int id)
        {
            return await _context.Places.FirstOrDefaultAsync(i => i.Id == id);
        }
        public Task<int> UpdatePlace(Place place)
        {
            _context.Places.Update(place);
            return _context.SaveChangesAsync();
        }

        public Task<int> AddPlace(Place place)
        {
            _context.Places.Add(place);
            return _context.SaveChangesAsync();
        }
    }
}
