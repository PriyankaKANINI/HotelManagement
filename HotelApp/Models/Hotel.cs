
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId  { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int PricePerNight { get; set; }
        public string? HotelAmenities { get; set; }

        // establish a one-to-many relationship where a hotel can have multiple rooms.
        public ICollection<Room>?Rooms { get; set; }

        public ICollection<HotelStaff>? HotelStaffs { get; set; }
        public ICollection<User>?Users { get; set; } 
    }
}
