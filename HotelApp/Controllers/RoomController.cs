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
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo _roomRepo;

        public RoomController(IRoomRepo roomRepo)
        {
            _roomRepo = roomRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Room>))]
        public IActionResult GetRoom()
        {
            var rooms = _roomRepo.GetRoom();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Room))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRoomById(int id)
        {
            var room = _roomRepo.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Room))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostRoom(Room room)
        {
            var createdRoom = _roomRepo.PostRoom(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = createdRoom.RoomId }, createdRoom);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Room))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutRoom(int id, Room room)
        {
            var updatedRoom = _roomRepo.PutRoom(id, room);
            if (updatedRoom == null)
            {
                return NotFound();
            }
            return Ok(updatedRoom);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Room))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRoom(int id)
        {
            var deletedRoom = _roomRepo.DeleteRoom(id);
            if (deletedRoom == null)
            {
                return NotFound();
            }
            return Ok(deletedRoom);
        }
    }
}
