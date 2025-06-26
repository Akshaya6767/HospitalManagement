using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class DoctorSchedule
    {
        [ForeignKey(nameof(DoctorDetails))]
        public int DoctorID { get; set; }
        public virtual DoctorDetail DoctorDetails { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual ICollection<PatientProfile> ApptDates { get; set; }
        public DateOnly AppDate { get; set; }

        public TimeOnly AvailableTimeSLot { get; set; }
    }
}
