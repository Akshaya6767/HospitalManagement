using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Services.Service
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;

        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
        }

        public async Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            return await _medicalHistoryRepository.AddMedicalHistoryAsync(medicalHistory);
        }

        public async Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync()
        {
            return await _medicalHistoryRepository.GetAllMedicalHistoriesAsync();
        }

        public async Task<MedicalHistory> GetMedicalHistoryByIdAsync(int historyID)
        {
            return await _medicalHistoryRepository.GetMedicalHistoryByIdAsync(historyID);
        }

        public async Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            await _medicalHistoryRepository.UpdateMedicalHistoryAsync(medicalHistory);
        }
    }
}
