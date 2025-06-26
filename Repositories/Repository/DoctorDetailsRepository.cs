using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
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
        public async Task<DoctorDetail> GetDocDetailByNameAsync(string DoctorName)
        {
            return await _context.DoctorDetails.FindAsync(DoctorName);
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
    }

}