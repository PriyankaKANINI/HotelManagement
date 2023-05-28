
using System.Collections.Generic;

using HotelApp.Models;

namespace HotelApp.Interfaces
{
    public interface IHotelStaffRepo
    {
        IEnumerable<HotelStaff> GetEmployees();
        HotelStaff GetEmployeesById(int StaffId);
        HotelStaff PostEmployee(HotelStaff Staff);
        HotelStaff PutEmployee(int StaffId, HotelStaff staff);
        HotelStaff DeleteEmployee(int StaffId);
    }
}
