using System.Collections.Generic;
using HotelApp.Interfaces;
using HotelApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepo _hotelRepo;

        public HotelController(IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Hotel>))]
        public IActionResult GetHotel()
        {
            var hotels = _hotelRepo.GetHotel();
            return Ok(hotels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelRepo.GetHotelById(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostHotel(Hotel hotel)
        {
            var createdHotel = _hotelRepo.PostHotel(hotel);
            return CreatedAtAction(nameof(GetHotelById), new { id = createdHotel.HotelId }, createdHotel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutHotel(int id, Hotel hotel)
        {
            var updatedHotel = _hotelRepo.PutHotel(id, hotel);
            if (updatedHotel == null)
            {
                return NotFound();
            }
            return Ok(updatedHotel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Hotel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteHotel(int id)
        {
            var deletedHotel = _hotelRepo.DeleteHotel(id);
            if (deletedHotel == null)
            {
                return NotFound();
            }
            return Ok(deletedHotel);
        }
    }
}
