using Microsoft.EntityFrameworkCore;
using MokkiApp.Models;
using MokkiApp.Repositories;

namespace MokkiApp.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository ?? throw new ArgumentNullException(nameof(placeRepository));
        }
        public async Task<List<Place>> GetAllPlacesAsync()
        {
            return await _placeRepository.GetAllPlacesAsync();
        }
        public async Task<Place> GetPlaceAsync(int id)
        {
            var place = await _placeRepository.GetPlaceAsync(id);
            return place;
        }
        public async Task<Place> UpdatePlace(int id, Place place)
        {
            var places = await _placeRepository.GetAllPlacesAsync();
            var thePlace = await _placeRepository.GetPlaceAsync(id);

            if (place != null)
            {

                if (places.Count(p => p.Id == place.Id) > 1) throw new ArgumentException(nameof(place.Id));
                await _placeRepository.UpdatePlace(thePlace);
                return thePlace;
            }
            throw new ArgumentException(nameof(id));
        }
        public async Task<Place> AddPlace(Place place)
        {
            return _placeRepository.AddPlace(place);
            //var thePlace = await _placeRepository.GetAllPlacesAsync();
            //if (!await _placeRepository.PlaceExistsAsync(place.Id))
            //{
            //    Place place1 = new Place();
            //    Place.Id = place1.Id;

            //    return _placeRepository.AddPlace(place);



            //    return place1;
            //}
            //throw new Exception("Product exists");
        }
    }
}
