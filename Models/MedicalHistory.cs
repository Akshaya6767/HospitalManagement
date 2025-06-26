using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class MedicalHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryID { get; set; }

        [ForeignKey(nameof(PatientProfile))]
        public int PatientID { get; set; }
        public virtual PatientProfile PatientProfile { get; set; }
        [Required]
        [StringLength(300)]
        public required string Diagnosis { get; set; }

        [Required]
        [StringLength(300)]
        public required string Treatment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfVisit { get; set; }
    }
}
