
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class HotelStaff
    {
        [Key]
        public int StaffId { get; set; }
        public string? Name { get; set; }
        public string? Salary { get; set; }
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
