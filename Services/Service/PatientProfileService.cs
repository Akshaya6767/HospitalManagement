using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Services.Service
{
    public class PatientProfileService : IPatientProfileService
    {
        private readonly IPatientProfileRepository _patientProfileRepository;
        public PatientProfileService(IPatientProfileRepository patientProfileRepository)
        {
            _patientProfileRepository = patientProfileRepository;
        }

        public async Task<PatientProfile> AddPatientProfileAsync(PatientProfileDTO patientProfiledto)
        {
            var pp = new PatientProfile
            {
                PatientName = patientProfiledto.PatientName,
                Address = patientProfiledto.Address,
                DateOfBirth = patientProfiledto.DateOfBirth,
                PhoneNumber = patientProfiledto.PhoneNumber,
                Gender = patientProfiledto.Gender
            };
            return await _patientProfileRepository.AddPatientProfileAsync(pp);
        }

        public async Task<IEnumerable<PatientProfile>> GetAllPatientProfileAsync()
        {
            return await _patientProfileRepository.GetAllPatientProfileAsync();
        }

        public async Task<PatientProfile> GetPatientProfileByIdAsync(int PatientID)
        {
            return await _patientProfileRepository.GetPatientProfileByIdAsync(PatientID);
        }

        public async Task DeletePatientProfileAsync(int PatientID)
        {
            await _patientProfileRepository.DeletePatientProfileAsync(PatientID);
        }

        public async Task UpdatePatientProfileAsync(int PatientID, PatientProfileDTO patientProfiledto)
        {
            var updatepp= new PatientProfile
            {
                PatientName = patientProfiledto.PatientName,
                Address = patientProfiledto.Address,
                DateOfBirth = patientProfiledto.DateOfBirth,
                PhoneNumber = patientProfiledto.PhoneNumber,
                Gender = patientProfiledto.Gender,
                
            };

            updatepp.SetDateOfBirth(patientProfiledto.DateOfBirth);
            await _patientProfileRepository.UpdatePatientProfileAsync(PatientID, updatepp);
        }
       
    }
}
