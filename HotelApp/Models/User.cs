using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string ?UserName { get; set; }
        public string ?UserEmail { get; set; }
        public string?UserPhone {  get; set; }
        public int UserAge { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
