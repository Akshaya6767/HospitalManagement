using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Services.Service
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IDoctorScheduleRepository _repository;

        public DoctorScheduleService(IDoctorScheduleRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync() =>
            _repository.GetAvailableSlotsAsync();

        public Task<bool> MarkAvailabilityAsync(DoctorScheduleDTO dto) =>
            _repository.MarkAvailabilityAsync(dto.DoctorID, dto.AvailableDate, dto.SlotID);

        public Task<IEnumerable<DoctorSchedule>> GetAvailabilityByDoctorAsync(int doctorId) =>
            _repository.GetAvailabilityByDoctorAsync(doctorId);
    }
}

