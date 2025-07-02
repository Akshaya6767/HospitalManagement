using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;

namespace HospitalManagement.Services.Interface
{
    public interface ITimeSlotService
    {
        IEnumerable<TimeSlotDTO> GetAll();
        TimeSlotDTO GetById(int id);
        void Add(TimeSlotDTO dto);
        void Update(TimeSlotDTO dto);
        void Delete(int id);
    }
}

