using HotelApp.Interfaces;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace HotelApp.Services
{
    public class HotelStaffRepo : IHotelStaffRepo 
    {
        private readonly HotelContext _staffContext;
        public HotelStaffRepo(HotelContext context)
        {
            _staffContext = context;
        }
        public IEnumerable<HotelStaff> GetEmployees()
        {
            return _staffContext.hotelStaff.ToList();
        }

        public HotelStaff GetEmployeesById(int employeeId)
        {
            return _staffContext.hotelStaff.FirstOrDefault(x => x.StaffId == employeeId);
        }

        public HotelStaff PostEmployee(HotelStaff employee)
        {
            var hotel = _staffContext.Hotels.Find(employee.Hotel.HotelId);
            if (hotel == null)
            {
                throw new ArgumentException("Invalid Hotel ID");
            }

            employee.Hotel = hotel;
            _staffContext.Add(employee);
            _staffContext.SaveChanges();
            return employee;
        }

        public HotelStaff PutEmployee(int employeeId, HotelStaff employee)
        {
            var existingEmployee = _staffContext.hotelStaff.Find(employeeId);
            if (existingEmployee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            var hotel = _staffContext.Hotels.Find(employee.Hotel.HotelId);
            if (hotel == null)
            {
                throw new ArgumentException("Invalid Hotel ID");
            }

            employee.Hotel = hotel;
            _staffContext.Entry(employee).State = EntityState.Modified;
            _staffContext.SaveChanges();
            return employee;
        }

        public HotelStaff DeleteEmployee(int employeeId)
        {
            var employee = _staffContext.hotelStaff.Find(employeeId);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            _staffContext.hotelStaff.Remove(employee);
            _staffContext.SaveChanges();
            return employee;
        }
    }
}