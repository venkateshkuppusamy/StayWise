using System.Data;
using API.Models;
using Dapper;

namespace API.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel?> GetByIdAsync(int id);
        Task<int> AddAsync(Hotel hotel);
        Task<int> UpdateAsync(Hotel hotel);
        Task<int> DeleteAsync(int id);
    }

    public class HotelRepository : IHotelRepository
    {
        private readonly IDbConnection _dbConnection;

        public HotelRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Hotel>> GetAllAsync()
        {
            const string query = "SELECT HotelId, Name, Location, Rating, PhoneNo, Email, CreatedBy, UpdatedBy, CreatedAt, UpdatedAt FROM Hotels";
            return await _dbConnection.QueryAsync<Hotel>(query);
        }

        public async Task<Hotel?> GetByIdAsync(int id)
        {
            const string query = "SELECT HotelId, Name, Location, Rating, PhoneNo, Email, CreatedBy, UpdatedBy, CreatedAt, UpdatedAt FROM Hotels WHERE HotelId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Hotel>(query, new { Id = id });
        }

        public async Task<int> AddAsync(Hotel hotel)
        {
            const string query = @"
                INSERT INTO Hotels (Name, Location, Rating, PhoneNo, Email, CreatedBy, UpdatedBy, CreatedAt, UpdatedAt)
                VALUES (@Name, @Location, @Rating, @PhoneNo, @Email, @CreatedBy, @UpdatedBy, @CreatedAt, @UpdatedAt)";
            return await _dbConnection.ExecuteAsync(query, hotel);
        }

        public async Task<int> UpdateAsync(Hotel hotel)
        {
            const string query = @"
                UPDATE Hotels
                SET Name = @Name,
                    Location = @Location,
                    Rating = @Rating,
                    PhoneNo = @PhoneNo,
                    Email = @Email,
                    CreatedBy = @CreatedBy,
                    UpdatedBy = @UpdatedBy,
                    CreatedAt = @CreatedAt,
                    UpdatedAt = @UpdatedAt
                WHERE HotelId = @HotelId";
            return await _dbConnection.ExecuteAsync(query, hotel);
        }

        public async Task<int> DeleteAsync(int id)
        {
            const string query = "DELETE FROM Hotels WHERE HotelId = @Id";
            return await _dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
