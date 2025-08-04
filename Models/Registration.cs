using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class Registration
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int PatientID { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string PatientAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(15)]
        public required string PhoneNumber { get; set; } // PK Combined

        [Required]
        [RegularExpression(@"^[MFT]$")]
        public char Gender { get; set; }

        [StringLength(50)]
        public required string Username { get; set; } // Will be set as Name + PatientID

        [Required]
        [StringLength(20)]
        public required string Role { get; set; } // 'Doctor', 'Patient', or 'Admin'

        [Required]
        [StringLength(255)]
        public required string Password { get; set; } // Should be stored hashed
    }
}
