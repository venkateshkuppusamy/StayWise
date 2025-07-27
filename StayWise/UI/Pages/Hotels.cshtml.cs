using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UI.Pages
{
    public class HotelsModel : PageModel
    {
        // In-memory list to simulate a database
        private static List<Hotel> _hotelList = new();

        [BindProperty]
        public Hotel Hotel { get; set; } = new();

        public List<Hotel> Hotels { get; set; } = new();

        public void OnGet()
        {
            // Load the list of hotels
            Hotels = _hotelList;
        }

        public IActionResult OnPostSave()
        {
            if (!ModelState.IsValid)
            {
                Hotels = _hotelList;
                return Page();
            }

            if (Hotel.HotelId == 0)
            {
                // Add new hotel
                Hotel.HotelId = _hotelList.Count > 0 ? _hotelList.Max(h => h.HotelId) + 1 : 1;
                _hotelList.Add(Hotel);
            }
            else
            {
                // Update existing hotel
                var existingHotel = _hotelList.FirstOrDefault(h => h.HotelId == Hotel.HotelId);
                if (existingHotel != null)
                {
                    existingHotel.Name = Hotel.Name;
                    existingHotel.Location = Hotel.Location;
                }
            }

            return RedirectToPage();
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                Hotels = _hotelList;
                return Page();
            }

            if (Hotel.HotelId == 0)
            {
                // Add new hotel
                Hotel.HotelId = _hotelList.Count > 0 ? _hotelList.Max(h => h.HotelId) + 1 : 1;
                _hotelList.Add(Hotel);
            }
            else
            {
                // Update existing hotel
                var existingHotel = _hotelList.FirstOrDefault(h => h.HotelId == Hotel.HotelId);
                if (existingHotel != null)
                {
                    existingHotel.Name = Hotel.Name;
                    existingHotel.Location = Hotel.Location;
                }
            }
            return RedirectToPage();

        }

        public IActionResult OnPostDelete(int id)
        {
            // Delete hotel
            var hotel = _hotelList.FirstOrDefault(h => h.HotelId == id);
            if (hotel != null)
            {
                _hotelList.Remove(hotel);
            }

            return RedirectToPage();
        }

       
    }
    public class Hotel
    {
        public int HotelId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
