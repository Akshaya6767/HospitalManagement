using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly HospitalManagementDbContext _context;

        public TimeSlotRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimeSlot> GetAll() => _context.TimeSlots.ToList();

        public TimeSlot GetById(int id) => _context.TimeSlots.Find(id);

        public void Add(TimeSlot timeSlot) => _context.TimeSlots.Add(timeSlot);

        public void Update(TimeSlot timeSlot) => _context.TimeSlots.Update(timeSlot);

        public void Delete(int id)
        {
            var slot = _context.TimeSlots.Find(id);
            if (slot != null)
                _context.TimeSlots.Remove(slot);
        }

        public void Save() => _context.SaveChanges();
    }
}
