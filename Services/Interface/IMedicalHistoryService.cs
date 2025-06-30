using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IMedicalHistoryService
    {
        Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync();
        Task<MedicalHistory> GetMedicalHistoryByIdAsync(int historyID);
        Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory);
    }
}

