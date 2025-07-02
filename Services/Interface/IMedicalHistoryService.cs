using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IMedicalHistoryService
    {
        Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistoryDTO medicalHistorydto);
        Task AddMedicalHistoryAsync(MedicalHistory medicalHistory);
        Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync();
        Task<MedicalHistory> GetMedicalHistoryByIdAsync(int historyID);
        Task UpdateMedicalHistoryAsync(int historyID, MedicalHistoryDTO medicalHistorydto);
    }
}

