
using HotelApp.Models;

namespace HotelApp.Interfaces
{
    public interface IHotelRepo
    {
        IEnumerable<Hotel> GetHotel();
        Hotel GetHotelById(int HotelId);
        Hotel PostHotel(Hotel hotel);
        Hotel PutHotel(int HotelId, Hotel hotel);
        Hotel DeleteHotel(int HotelId);
    }
}
