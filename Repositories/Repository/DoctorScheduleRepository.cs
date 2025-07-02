using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories.Repository
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        private readonly HospitalManagementDbContext _context;

        public DoctorScheduleRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeSlot>> GetAvailableSlotsAsync() =>
            await _context.TimeSlots.ToListAsync();

        public async Task<bool> MarkAvailabilityAsync(int doctorId, DateOnly date, int slotId)
        {
            var slot = await _context.TimeSlots.FindAsync(slotId);
            if (slot == null) return false;

            var schedule = new DoctorSchedule
            {
                DoctorID = doctorId,
                AppDate = date,
                AvailableTimeSLot = slot.Slot
            };

            _context.DoctorSchedules.Add(schedule);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DoctorSchedule>> GetAvailabilityByDoctorAsync(int doctorId) =>
            await _context.DoctorSchedules
                          .Where(ds => ds.DoctorID == doctorId)
                          .ToListAsync();
    }
}


