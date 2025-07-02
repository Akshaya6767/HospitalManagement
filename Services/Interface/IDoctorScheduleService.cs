using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IDoctorScheduleService
    {
        Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync();
        Task<bool> MarkAvailabilityAsync(DoctorScheduleDTO dto);
        Task<IEnumerable<DoctorSchedule>> GetAvailabilityByDoctorAsync(int doctorId);
    }
}

