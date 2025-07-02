using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class DoctorDetail
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string DoctorName { get; set; }

        [Required]
        [StringLength(30)]
        public string ConsultationVenue { get; set; }

        [Required]
        public string Qualification { get; set; }
        public string Speciality { get; set; }
    }
}
