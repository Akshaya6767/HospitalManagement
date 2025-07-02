using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IAppoinmentService
    {
        Task<Appointment> CreateAsync(AppointmentDTO dto);
        Task<Appointment?> UpdateAsync(int id, AppointmentDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId);
        Task<IEnumerable<Appointment>> GetUpcomingByPatientAsync(int phoneNumber);
    }
}


