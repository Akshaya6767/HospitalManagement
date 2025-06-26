using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.DTOs
{
    public class DoctorScheduleDTO
    {
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual ICollection<PatientProfile> ApptDates { get; set; }
        public DateOnly AppDate { get; set; }

        public TimeOnly AvailableTimeSLot { get; set; }
    }
}
