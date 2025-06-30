using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories.Repository
{
    public class DoctorDetailsRepository : IDoctorDetailsRepository
    {
        private readonly HospitalManagementDbContext _context;

        public DoctorDetailsRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<DoctorDetail> AddDocDetailAsync(DoctorDetail doctorDetail)
        {
            await _context.DoctorDetails.AddAsync(doctorDetail);
            await _context.SaveChangesAsync();
            return doctorDetail;
        }

        public async Task<IEnumerable<DoctorDetail>> GetAllDocDetailAsync()
        {
            return await _context.DoctorDetails
                .ToListAsync();
        }

        public async Task<DoctorDetail> GetDocDetailByNameAsync(string doctorName)
        {
            return await _context.DoctorDetails.FirstOrDefaultAsync(d => d.DoctorName == doctorName);
        }
        
        public async Task DeleteDocDetailsAsync(int DoctorId)
        {
            var docid = await _context.DoctorDetails.FindAsync(DoctorId);
            if (docid != null)
            {
                _context.DoctorDetails.Remove(docid);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDoctorDetailAsync(int doctorId, DoctorDetail doctorDetail)
        {
            // Validate doctorId
            if (doctorId != doctorDetail.DoctorId)
            {
                throw new ArgumentException("The doctorId does not match the DoctorID in the provided details.");
            }

            _context.Entry(doctorDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorDetail>> GetDocDetailByIdAndNameAsync(int doctorId, string doctorName)
        {
            return await _context.DoctorDetails
                                 .Where(d => d.DoctorId == doctorId && d.DoctorName.Contains(doctorName))
                                 .ToListAsync();
        }

        
    }
}