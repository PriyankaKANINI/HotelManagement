using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class UserAuthorize
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string ?UserEmail { get; set; }
        public string? Password { get; set; }
    }
}
