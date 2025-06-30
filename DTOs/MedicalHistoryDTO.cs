using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DTOs
{
    public class MedicalHistoryDTO
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int HistoryID { get; internal set; }

            [Required]
            [StringLength(300)]
            public string Diagnosis { get; set; }

            [Required]
            [StringLength(300)]
            public string Treatment { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime DateOfVisit { get; set; }
        
        
    }
}
