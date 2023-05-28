

using HotelApp.Models;

namespace HotelApp.Interfaces
{
    public interface IRoomRepo
    {
        IEnumerable<Room> GetRoom();
        Room GetRoomById(int RoomId);
        Room PostRoom(Room room);
        Room PutRoom(int RoomId, Room room);
        Room DeleteRoom(int RoomId);
    }
}
