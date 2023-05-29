using HotelApp.Interfaces;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelApp.Services
{
    public class RoomRepo : IRoomRepo
    {
        private readonly HotelContext _roomContext;

        public RoomRepo(HotelContext context)
        {
            _roomContext = context;
        }

        public IEnumerable<Room> GetRoom()
        {
            return _roomContext.Rooms.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            return _roomContext.Rooms.FirstOrDefault(x => x.RoomId == roomId);
        }

        
        
        public Room PostRoom(Room room)
        {
            var hotel = _roomContext.Hotels.Find(room.Hotel.HotelId);
            if (hotel == null)
            {
                throw new ArgumentException("Invalid Hotel ID");
            }

            room.Hotel = hotel;
            _roomContext.Add(room);
            _roomContext.SaveChanges();
            return room;
        }

        public Room PutRoom(int roomId, Room room)
        {
            var existingRoom = _roomContext.Rooms.Find(roomId);
            if (existingRoom == null)
            {
                throw new ArgumentException("Room not found");
            }

            var hotel = _roomContext.Hotels.Find(room.Hotel.HotelId);
            if (hotel == null)
            {
                throw new ArgumentException("Invalid Hotel ID");
            }

            room.Hotel = hotel;
            _roomContext.Entry(room).State = EntityState.Modified;
            _roomContext.SaveChanges();
            return room;
        }

        public Room DeleteRoom(int roomId)
        {
            var room = _roomContext.Rooms.Find(roomId);
            if (room == null)
            {
                throw new ArgumentException("Room not found");
            }
            _roomContext.Rooms.Remove(room);
            _roomContext.SaveChanges();
            return room;
        }
    }
}
