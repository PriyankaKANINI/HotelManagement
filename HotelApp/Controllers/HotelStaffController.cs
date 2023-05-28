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
    public class HotelStaffController : ControllerBase
    {
        private readonly IHotelStaffRepo _hotelStaffRepo;

        public HotelStaffController(IHotelStaffRepo hotelStaffRepo)
        {
            _hotelStaffRepo = hotelStaffRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HotelStaff>))]
        public IActionResult GetEmployees()
        {
            var employees = _hotelStaffRepo.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelStaff))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployeesById(int id)
        {
            var employee = _hotelStaffRepo.GetEmployeesById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HotelStaff))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostEmployee(HotelStaff staff)
        {
            var createdEmployee = _hotelStaffRepo.PostEmployee(staff);
            return CreatedAtAction(nameof(GetEmployeesById), new { id = createdEmployee.StaffId }, createdEmployee);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelStaff))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutEmployee(int id, HotelStaff staff)
        {
            var updatedEmployee = _hotelStaffRepo.PutEmployee(id, staff);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HotelStaff))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(int id)
        {
            var deletedEmployee = _hotelStaffRepo.DeleteEmployee(id);
            if (deletedEmployee == null)
            {
                return NotFound();
            }
            return Ok(deletedEmployee);
        }
    }
}
