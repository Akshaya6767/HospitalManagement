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
    public class AppointmentService : IAppoinmentService
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentService(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Appointment> CreateAsync(AppointmentDTO dto)
        {
            var appointment = new Appointment
            {
                DoctorID = dto.DoctorID,
                AppointmentDate = dto.AppointmentDate,
                Speciality = dto.Speciality,
                Concern = dto.Concern,
                Slot = dto.Slot,
                PhoneNumber = dto.PhoneNumber,
                ConsultationVenue = dto.ConsultationVenue,
                Status = Appointment.Stats.Scheduled
            };
            return await _repository.CreateAsync(appointment);
        }

        public async Task<Appointment?> UpdateAsync(int id, AppointmentDTO dto)
        {
            var updated = new Appointment
            {
                AppointmentDate = dto.AppointmentDate,
                Speciality = dto.Speciality,
                Concern = dto.Concern,
                Slot = dto.Slot,
                PhoneNumber = dto.PhoneNumber,
                ConsultationVenue = dto.ConsultationVenue,
                Status = Appointment.Stats.Scheduled
            };
            return await _repository.UpdateAsync(id, updated);
        }

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
        public Task<IEnumerable<Appointment>> GetAllAsync() => _repository.GetAllAsync();
        public Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId) => _repository.GetByDoctorIdAsync(doctorId);
        public Task<IEnumerable<Appointment>> GetUpcomingByPatientAsync(int phoneNumber) => _repository.GetUpcomingByPatientAsync(phoneNumber);
    }
}

