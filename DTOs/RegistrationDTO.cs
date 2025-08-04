using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string PatientAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(15)]
        public required string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[MFT]$")]
        public char Gender { get; set; }

        [Required]
        [StringLength(20)]
        public required string Role { get; set; } // 'Doctor' or 'Patient'

        [Required]
        [StringLength(255)]
        public required string Password { get; set; }
    }
}
