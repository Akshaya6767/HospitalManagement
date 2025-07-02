using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface ITimeSlotRepository
    {
        IEnumerable<TimeSlot> GetAll();
        TimeSlot GetById(int id);
        void Add(TimeSlot timeSlot);
        void Update(TimeSlot timeSlot);
        void Delete(int id);
        void Save();
        
    }

}

