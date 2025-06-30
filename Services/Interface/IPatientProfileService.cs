using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IPatientProfileService
    {
        Task<PatientProfile> AddPatientProfileAsync(PatientProfileDTO patientProfiledto);
        Task<IEnumerable<PatientProfile>> GetAllPatientProfileAsync();
        Task<PatientProfile> GetPatientProfileByIdAsync(int PatientID);
        Task DeletePatientProfileAsync(int PatientID);
        Task UpdatePatientProfileAsync(int PatientID, PatientProfileDTO patientProfiledto);


    }
}
