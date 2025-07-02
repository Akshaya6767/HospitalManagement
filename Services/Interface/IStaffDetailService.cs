using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public interface IStaffDetailService
    {
        Task<IEnumerable<StaffDetail>> GetAllAsync();
        Task<StaffDetail?> GetByIdAsync(int id);
        Task<IEnumerable<StaffDetail>> GetByNameAsync(string name);
        Task<StaffDetail> AddAsync(StaffDetail staff);
        Task<StaffDetail?> UpdateAsync(int id, StaffDetail staff);
        Task<bool> DeleteAsync(int id);
    }
}
