

using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.DTOs
{
    public class AppointmentDTO
    {
        [Required]
        public int DoctorID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly AppointmentDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Concern { get; set; } = string.Empty;

        [Required]
        public TimeOnly Slot { get; set; }

        [Required]
        [RegularExpression(@"^\\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public int PhoneNumber { get; set; }

        public string? Speciality { get; set; }

        public string? ConsultationVenue { get; set; }

        public string? Status { get; set; }// Scheduled, Cancelled, Completed
    }
}


