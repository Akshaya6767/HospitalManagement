using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface IPatientProfileRepository
    {
        Task<PatientProfile> AddPatientProfileAsync(PatientProfile patientProfile);
        Task<IEnumerable<PatientProfile>> GetAllPatientProfileAsync();
        Task<PatientProfile> GetPatientProfileByIdAsync(int PatientID);
        Task DeletePatientProfileAsync(int PatientID);
        Task UpdatePatientProfileAsync(int PatientID, PatientProfile patientProfile);
        
    }
}
