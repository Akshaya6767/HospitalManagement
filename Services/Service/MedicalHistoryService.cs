using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Services.Service
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        private readonly IMedicalHistoryRepository _medicalHistoryRepository;
        private readonly IPatientProfileRepository _patientProfileRepository;

        public MedicalHistoryService(IMedicalHistoryRepository medicalHistoryRepository, IPatientProfileRepository patientProfileRepository)
        {
            _medicalHistoryRepository = medicalHistoryRepository;
            _patientProfileRepository = patientProfileRepository;
        }

        public async Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistoryDTO medicalHistorydto)
        {
            var patient = await _patientProfileRepository.GetPatientProfileByIdAsync(medicalHistorydto.PatientID);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            var medicalHistory = new MedicalHistory
            {
                PatientID = medicalHistorydto.PatientID,
                Diagnosis = medicalHistorydto.Diagnosis,
                Treatment = medicalHistorydto.Treatment,
                DateOfVisit = medicalHistorydto.DateOfVisit,
                PatientName = patient.PatientName,
                Age = patient.Age,
                PatientProfile = patient
            };

            return await _medicalHistoryRepository.AddMedicalHistoryAsync(medicalHistory);
        }

        public Task AddMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync()
        {
            return await _medicalHistoryRepository.GetAllMedicalHistoriesAsync();
        }

        public async Task<MedicalHistory> GetMedicalHistoryByIdAsync(int historyID)
        {
            var medicalHistory = await _medicalHistoryRepository.GetMedicalHistoryByIdAsync(historyID);
            if (medicalHistory == null)
            {
                throw new Exception("Medical history not found");
            }

            var patient = await _patientProfileRepository.GetPatientProfileByIdAsync(medicalHistory.PatientID);
            if (patient != null)
            {
                medicalHistory.PatientName = patient.PatientName;
                medicalHistory.Age = patient.Age;
            }

            return medicalHistory;
        }

        public async Task UpdateMedicalHistoryAsync(MedicalHistoryDTO medicalHistorydto)
        {
            var patient = await _patientProfileRepository.GetPatientProfileByIdAsync(medicalHistorydto.PatientID);
            if (patient == null)
            {
                throw new Exception("Patient not found");
            }

            var medicalHistory = new MedicalHistory
            {
                HistoryID = medicalHistorydto.HistoryID,
                PatientID = medicalHistorydto.PatientID,
                Diagnosis = medicalHistorydto.Diagnosis,
                Treatment = medicalHistorydto.Treatment,
                DateOfVisit = medicalHistorydto.DateOfVisit,
                PatientName = patient.PatientName,
                Age = patient.Age,
                PatientProfile = patient
            };

            await _medicalHistoryRepository.UpdateMedicalHistoryAsync(medicalHistory);
        }

        public Task UpdateMedicalHistoryAsync(int historyID, [FromBody] MedicalHistoryDTO medicalHistorydto)
        {
            throw new NotImplementedException();
        }
    }
}


