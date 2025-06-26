using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DTOs
{
    public class PatientProfileDTO
    {
        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string PatientName { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly DateOfBirth { get; set; }


        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [AllowedValues(typeof(int))]
        public required int PhoneNumber { get; set; }


        [Required]
        [RegularExpression(@"^[MFT]$")]
        public char Gender { get; set; }
       
    }
}
