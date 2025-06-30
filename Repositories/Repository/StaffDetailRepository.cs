using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;



namespace HospitalManagement.Repositories.Repository
{
    public class StaffDetailRepository : IStaffDetailRepository
    {
        private readonly HospitalManagementDbContext _context;

        public StaffDetailRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<StaffDetail> AddStaffDetailAsync(StaffDetail staffDetail)
        {
            await _context.StaffDetails.AddAsync(staffDetail);
            await _context.SaveChangesAsync();
            return staffDetail;
        }

        public async Task<IEnumerable<StaffDetail>> GetAllStaffDetailAsync()
        {
            return await _context.StaffDetails.ToListAsync();
        }

        public async Task<StaffDetail> GetStaffDetailByNameAsync(string staffName)
        {
            return await _context.StaffDetails.FirstOrDefaultAsync(d => d.StaffName == staffName);
        }

        public async Task DeleteStaffDetailsAsync(int staffID)
        {
            var staffDetail = await _context.StaffDetails.FindAsync(staffID);
            if (staffDetail != null)
            {
                _context.StaffDetails.Remove(staffDetail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateStaffDetailAsync(int staffId, StaffDetail staffDetail)
        {
            if (staffId != staffDetail.StaffID)
            {
                throw new ArgumentException("The staffId does not match the StaffID in the provided details.");
            }

            _context.Entry(staffDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<StaffDetail> GetStaffDetailByIdAndNameAsync(int staffId, string staffName)
        {
            return await _context.StaffDetails
                                 .Where(d => d.StaffID == staffId && d.StaffName.Contains(staffName))
                                 .FirstOrDefaultAsync();
        }
    }
}
