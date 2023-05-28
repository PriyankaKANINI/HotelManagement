using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;


namespace HotelApp.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? Number { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
