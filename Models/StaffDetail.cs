using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class StaffDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public required string StaffName { get; set; }

        [Required]
        [StringLength(20)]
        public required string Designation { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [AllowedValues(typeof(int))]
        public int StaffPhoneNumber { get; set; }
    }
}
