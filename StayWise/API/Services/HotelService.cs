using API.Models;
using API.Repositories;

namespace API.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel?> GetByIdAsync(int id);
        Task AddAsync(Hotel hotel);
        Task UpdateAsync(Hotel hotel);
        Task DeleteAsync(int id);
    }

    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;

        public HotelService(IHotelRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Hotel?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Hotel hotel) => await _repository.AddAsync(hotel);

        public async Task UpdateAsync(Hotel hotel) => await _repository.UpdateAsync(hotel);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}
