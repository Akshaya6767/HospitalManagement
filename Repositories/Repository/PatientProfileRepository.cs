using HospitalManagement;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Repositories.Repository;
using HospitalManagement.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories.Repository
{
    public class PatientProfileRepository : IPatientProfileRepository
    {
        private readonly HospitalManagementDbContext _context;

        public PatientProfileRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<PatientProfile> AddPatientProfileAsync(PatientProfile patientProfile)
        {
            await _context.PatientProfiles.AddAsync(patientProfile);
            await _context.SaveChangesAsync();
            return patientProfile;
        }

    }
}
