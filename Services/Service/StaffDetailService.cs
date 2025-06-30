using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Services.Service
{
    public class StaffDetailService : IStaffDetailService
    {
        private readonly IStaffDetailRepository _staffDetailRepository;

        public StaffDetailService(IStaffDetailRepository staffDetailRepository)
        {
            _staffDetailRepository = staffDetailRepository;
        }

        public async Task<StaffDetail> AddStaffDetailAsync(StaffDetail staffDetail)
        {
            return await _staffDetailRepository.AddStaffDetailAsync(staffDetail);
        }

        public async Task<IEnumerable<StaffDetail>> GetAllStaffDetailAsync()
        {
            return await _staffDetailRepository.GetAllStaffDetailAsync();
        }

        public async Task DeleteStaffDetailsAsync(int staffID)
        {
            await _staffDetailRepository.DeleteStaffDetailsAsync(staffID);
        }

        public async Task<StaffDetail> GetStaffDetailByIdAndNameAsync(int staffId, string staffName)
        {
            return await _staffDetailRepository.GetStaffDetailByIdAndNameAsync(staffId, staffName);
        }

        public async Task<StaffDetail> GetStaffDetailByNameAsync(string staffName)
        {
            return await _staffDetailRepository.GetStaffDetailByNameAsync(staffName);
        }

        public async Task UpdateStaffDetailAsync(int staffId, StaffDetail staffDetail)
        {
            await _staffDetailRepository.UpdateStaffDetailAsync(staffId, staffDetail);
        }
    }
}

