using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface IMedicalHistoryRepository
    {
        Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistoryDTO medicalHistorydto);
        Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync();
        Task<MedicalHistory> GetMedicalHistoryByIdAsync(int historyID);
        Task UpdateMedicalHistoryAsync(MedicalHistoryDTO medicalHistorydto);
        Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory);
    }
}


