using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }

        public string Name { get; set; } 

        public string? Location { get; set; }

        public decimal? Rating { get; set; }

        public string? PhoneNo { get; set; }

        public string? Email { get; set; }

        public string? CreatedBy { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
