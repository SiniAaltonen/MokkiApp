using MokkiApp.Models;

namespace MokkiApp.Repositories
{
    public interface IPlaceRepository
    {
        Task<List<Place>> GetAllPlacesAsync();

        Task<Place> GetPlaceAsync(int id);

        Task<int> UpdatePlace(Place place);

        Task<int> AddPlace(Place place);

        Task<bool> PlaceExistsAsync(int placeId);
    }
}
