using Microsoft.EntityFrameworkCore;
using HotelApp.Models;

namespace HotelApp.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelStaff> hotelStaff { get; set; }
        public DbSet<UserAuthorize> UserAuthorize { get; set; }
    }   
}
