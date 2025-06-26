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
    public class AppointmentDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentID { get; set; }

        [ForeignKey(nameof(PatientProfile))]
        public int PatientID { get; set; }

        [ForeignKey(nameof(DoctorSchedule))]
        public string DoctorName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly AppointmentDate { get; set; }
        public virtual ICollection<PatientProfile> ApptDates { get; set; }
        public string Speciality { get; set; }
        public string Concern { get; set; }
        public TimeOnly Slot { get; set; }
        public int PhoneNumber { get; set; }
        public string ReportingLocation { get; set; }
        public status Status { get; set; }

        public enum status
        {
            Scheduled,
            Cancelled,
            Completed
        }
    }
}
