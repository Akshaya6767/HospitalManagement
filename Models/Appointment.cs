using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
        public class Appointment
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AppointmentID { get; set; }

            [ForeignKey(nameof(DoctorDetails))]
            public int DoctorID { get; set; }
            public virtual DoctorDetail DoctorDetails { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public DateOnly AppointmentDate { get; set; }
            public virtual PatientProfile ApptDates { get; set; }

            public string? Speciality { get; set; }
            public required string Concern { get; set; }
            public TimeOnly Slot { get; set; }

            [Required]
            [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
            public int PhoneNumber { get; set; }

            public string? ConsultationVenue { get; set; }
            public Stats Status { get; set; }

            public enum Stats
            {
                Scheduled,
                Cancelled,
                Completed
            }
        }
}

