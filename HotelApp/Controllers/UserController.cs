using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HotelApp.Models;
using HotelApp.Interfaces;

namespace HotelApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepo us;
        public UserController(IUserRepo us)
        {
            this.us = us;
        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return us.GetUser();
        }

        [HttpGet("{id}")]
        public User GetById(int UserId)
        {
            return us.GetUserById(UserId);
        }

        [HttpPost]
        public User PostCustomer(User user)
        {
            return us.PostUser(user);
        }
        [HttpPut("{id}")]
        public User PutCustomer(int UserId, User user)
        {
            return us.PutUser(UserId, user);
        }
        [HttpDelete("{id}")]
        public User DeleteCustomer(int UserId)
        {
            return us.DeleteUser(UserId);
        }
        [HttpGet("filter")]
        public IEnumerable<Hotel> FilterHotels(string location)
        {
            return us.FilterHotels(location);
        }

        [HttpGet("filter/price")]
        public IEnumerable<Hotel> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {
            return us.FilterPriceRange(minPrice, maxPrice);
        }
        [HttpGet("filter/location")]
        public IEnumerable<Hotel> FilterLocation(string location)
        {
            return us.FilterLocation(location);
        }
    }
}