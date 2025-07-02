using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Services.Service
{
    public class TimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _repository;

        public TimeSlotService(ITimeSlotRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TimeSlotDTO> GetAll()
        {
            return _repository.GetAll().Select(ts => new TimeSlotDTO
            {
                SlotCode = ts.SlotCode,
                Slot = ts.Slot
            });
        }

        public TimeSlotDTO GetById(int id)
        {
            var ts = _repository.GetById(id);
            if (ts == null) return null;

            return new TimeSlotDTO
            {
                SlotCode = ts.SlotCode,
                Slot = ts.Slot
            };
        }

        public void Add(TimeSlotDTO dto)
        {
            var ts = new TimeSlot
            {
                SlotCode = dto.SlotCode,
                Slot = dto.Slot
            };
            _repository.Add(ts);
            _repository.Save();
        }

        public void Update(TimeSlotDTO dto)
        {
            var ts = new TimeSlot
            {
                SlotCode = dto.SlotCode,
                Slot = dto.Slot
            };
            _repository.Update(ts);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }
    }
}

