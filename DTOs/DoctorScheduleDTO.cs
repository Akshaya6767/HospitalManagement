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
        [Key]
        public int ScheduleID { get; set; }
        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public int SlotID { get; set; } // Selected from dropdown
    }
}
