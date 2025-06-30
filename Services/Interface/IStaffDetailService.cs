using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;
using HospitalManagement.Services.Service;

namespace HospitalManagement.Services.Interface
{
    public interface IStaffDetailService
    {

        Task<StaffDetail> AddStaffDetailAsync(StaffDetail staffDetail);

        Task<IEnumerable<StaffDetail>> GetAllStaffDetailAsync();


        Task DeleteStaffDetailsAsync(int staffID);

        Task<StaffDetail> GetStaffDetailByIdAndNameAsync(int staffId, string staffName);
        

        Task<StaffDetail> GetStaffDetailByNameAsync(string staffName);



        Task UpdateStaffDetailAsync(int staffId, StaffDetail staffDetail);
        
    }
}
