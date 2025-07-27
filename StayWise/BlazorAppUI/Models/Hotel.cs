using System.ComponentModel.DataAnnotations;

namespace BlazorAppUI.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Location { get; set; }
        public decimal? Rating { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
    }
}
