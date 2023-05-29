using HotelApp.Interfaces;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelApp.Services
{
    public class UserRepo:IUserRepo
    {
        private readonly HotelContext UserContext;
        public UserRepo(HotelContext con)
        {
            UserContext = con;
        }



        public IEnumerable<User> GetUser()
        {
            return UserContext.Users.ToList();
        }
        public User GetUserById(int UserId)
        {
            return UserContext.Users.FirstOrDefault(x => x.UserId == UserId);
        }

        public User PostUser(User User)
        {

            var cus = UserContext.Hotels.Find(User.Hotel.HotelId);
            User.Hotel = cus;
            UserContext.Add(User);
            UserContext.SaveChanges();
            return User;
        }

        public User PutUser(int UserId, User User)
        {
            var cus = UserContext.Hotels.Find(User.Hotel.HotelId);
            User.Hotel = cus; ;
            UserContext.Entry(User).State = EntityState.Modified;
            UserContext.SaveChangesAsync();
            return User;
        }

        public User DeleteUser(int UserId)
        {

            var cus = UserContext.Users.Find(UserId);


            UserContext.Users.Remove(cus);
            UserContext.SaveChanges();

            return cus;
        }
        public IEnumerable<Hotel> FilterLocation(string location)
        {
            try
            {
                var location_query = UserContext.Hotels.AsQueryable();

                if (!string.IsNullOrEmpty(location))
                {
                    location_query = location_query.Where(h => h.Location.Contains(location));
                }
                return location_query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering the location.", ex);
            }
        }

        //Filtering price range
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {
            try
            {
                var priceQuery = UserContext.Hotels.Include(x => x.Rooms).Where(r => r.PricePerNight >= minPrice && r.PricePerNight <= maxPrice);
                return priceQuery.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while filtering hotels based on price range.", ex);
            }
        }     




        public IEnumerable<Hotel> FilterHotels(string amenities)
        {
            var filteredHotels = UserContext.Hotels.AsQueryable();

            // Apply filters based on the provided criteria
            if (!string.IsNullOrEmpty(amenities))
            {
                filteredHotels = filteredHotels.Where(h => h.HotelAmenities.Contains(amenities));
            }



            return filteredHotels.ToList();

        }


    }
}
