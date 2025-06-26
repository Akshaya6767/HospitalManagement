using HospitalManagement;
using HospitalManagement.DTOs;
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

        public async Task<IEnumerable<PatientProfile>> GetAllPatientProfileAsync()
        {
            return await _context.PatientProfiles
                .ToListAsync();
        }
        public async Task<PatientProfile> GetPatientProfileByIdAsync(int PatientID)
        {
            return await _context.PatientProfiles.FindAsync(PatientID);
        }

        public async Task DeletePatientProfileAsync(int PatientID)
        {
            var patid = await _context.DoctorDetails.FindAsync(PatientID);
            if (patid != null)
            {
                _context.DoctorDetails.Remove(patid);
                await _context.SaveChangesAsync();
            }
        }

        public Task UpdatePatientProfileAsync(int PatientID, PatientProfileDTO patientProfileDTO)
        {
            var existingPatientProfile = _context.PatientProfiles.Find(PatientID);
            if (existingPatientProfile != null)
            {
                existingPatientProfile.PatientName = patientProfileDTO.PatientName;
                existingPatientProfile.Address = patientProfileDTO.Address;
                existingPatientProfile.DateOfBirth = patientProfileDTO.DateOfBirth;
                existingPatientProfile.PhoneNumber = patientProfileDTO.PhoneNumber;
                existingPatientProfile.Gender = patientProfileDTO.Gender;
                _context.PatientProfiles.Update(existingPatientProfile);
                _context.SaveChanges();
                return Task.FromResult(existingPatientProfile);
            }
            else
            {
                throw new KeyNotFoundException("Patient Profile not found.");
            }
        
        }
        

    }
}
