
//using System.Collections.Generic;
using HotelApp.Models;

namespace HotelApp.Interfaces
{
        public interface IUserRepo
        {
            IEnumerable<User> GetUser();
            User GetUserById(int UserId);
            User PostUser(User user);
            User PutUser(int UserId, User user);
            User DeleteUser(int UserId);
            IEnumerable<Hotel> FilterHotels(string location);
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice,decimal maxPrice);
        public IEnumerable<Hotel> FilterLocation(string location);
        }
    }
