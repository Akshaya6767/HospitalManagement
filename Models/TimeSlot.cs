using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class TimeSlot
    {
        [Key]
        public int SlotCode { get; set; }

        [Required]
        public required string Slot { get; set; }
    }
}
