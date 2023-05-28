using System;
using System.Collections.Generic;
using System.Linq;
using HotelApp.Models;
using HotelApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Services
{
    public class HotelRepo : IHotelRepo
    {
        private readonly HotelContext _hotelContext;

        //public HotelRepo(HotelContext context)
        //{
        //    _hotelContext = context ?? throw new ArgumentNullException(nameof(context));
        //}

        public HotelRepo(HotelContext context)
        {
            _hotelContext = context;
        }

        public IEnumerable<Hotel> GetHotel()
        {
            try
            {
                return _hotelContext.Hotels.Include(x => x.Rooms).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve hotels.", ex);
            }
        }

        public Hotel GetHotelById(int hotelId)
        {
            try
            {
                return _hotelContext.Hotels.FirstOrDefault(x => x.HotelId == hotelId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve hotel with ID {hotelId}.", ex);
            }
        }

        public Hotel PostHotel(Hotel hotel)
        {
            try
            {
                _hotelContext.Hotels.Add(hotel);
                _hotelContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add hotel.", ex);
            }
        }

        public Hotel PutHotel(int hotelId, Hotel hotel)
        {
            try
            {
                hotel.HotelId = hotelId;
                _hotelContext.Entry(hotel).State = EntityState.Modified;
                _hotelContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update hotel with ID {hotelId}.", ex);
            }
        }

        public Hotel DeleteHotel(int hotelId)
        {
            try
            {
                var hotel = _hotelContext.Hotels.Find(hotelId);
                if (hotel == null)
                {
                    return null;
                }

                _hotelContext.Hotels.Remove(hotel);
                _hotelContext.SaveChanges();
                return hotel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete hotel with ID {hotelId}.", ex);
            }
        }
    }
}
