using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BlazorAppUI.Models;

namespace BlazorAppUI.Services
{
    public class HotelService
    {
        private readonly HttpClient _httpClient;

        public HotelService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Hotel>> GetHotelsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Hotel>>("") ?? new List<Hotel>();
        }

        public async Task CreateHotelAsync(Hotel hotel)
        {
            await _httpClient.PostAsJsonAsync("", hotel);
        }

        public async Task UpdateHotelAsync(Hotel hotel)
        {
            await _httpClient.PutAsJsonAsync($"{hotel.HotelId}", hotel);
        }

        public async Task DeleteHotelAsync(int hotelId)
        {
            await _httpClient.DeleteAsync($"{hotelId}");
        }

        
    }
}
