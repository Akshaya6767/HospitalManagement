using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface IDoctorScheduleRepository
    {
        Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync();
        Task<bool> MarkAvailabilityAsync(int doctorId, DateOnly date, int slotId);
        Task<IEnumerable<DoctorSchedule>> GetAvailabilityByDoctorAsync(int doctorId);
    }
}