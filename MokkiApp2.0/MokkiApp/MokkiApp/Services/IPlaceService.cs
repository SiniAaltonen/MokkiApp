using MokkiApp.Models;

namespace MokkiApp.Services
{
    public interface IPlaceService
    {
        Task<List<Place>> GetAllPlacesAsync();

        Task<Place> GetPlaceAsync(int id);

        Task<Place> UpdatePlace(int id, Place place);

        Task<Place> AddPlace(Place place);
    }
}
