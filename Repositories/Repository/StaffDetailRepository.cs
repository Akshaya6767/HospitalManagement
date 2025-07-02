using System;
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class StaffDetailRepository : IStaffDetailRepository
    {
        private readonly HospitalManagementDbContext _context;

        public StaffDetailRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StaffDetail>> GetAllAsync() =>
            await _context.StaffDetails.ToListAsync();

        public async Task<StaffDetail?> GetByIdAsync(int id) =>
            await _context.StaffDetails.FindAsync(id);

        public async Task<IEnumerable<StaffDetail>> GetByNameAsync(string name) =>
            await _context.StaffDetails
                          .Where(s => s.StaffName.Contains(name))
                          .ToListAsync();

        public async Task<StaffDetail> AddAsync(StaffDetail staff)
        {
            _context.StaffDetails.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<StaffDetail?> UpdateAsync(int id, StaffDetail staff)
        {
            var existing = await _context.StaffDetails.FindAsync(id);
            if (existing == null) return null;

            existing.StaffName = staff.StaffName;
            existing.Designation = staff.Designation;
            existing.StaffPhoneNumber = staff.StaffPhoneNumber;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var staff = await _context.StaffDetails.FindAsync(id);
            if (staff == null) return false;

            _context.StaffDetails.Remove(staff);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
