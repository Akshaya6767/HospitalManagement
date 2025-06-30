using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface IStaffDetailRepository 
    {
        Task<StaffDetail> AddStaffDetailAsync(StaffDetail staffDetail);
        Task<IEnumerable<StaffDetail>> GetAllStaffDetailAsync();
        Task<StaffDetail> GetStaffDetailByNameAsync(string staffName);
        Task DeleteStaffDetailsAsync(int staffID);
        Task UpdateStaffDetailAsync(int staffId, StaffDetail staffDetail);
        Task<StaffDetail> GetStaffDetailByIdAndNameAsync(int staffId, string staffName);
    }
}
