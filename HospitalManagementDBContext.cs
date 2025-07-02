
using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement
{
    public class HospitalManagementDbContext : DbContext
    {
        public HospitalManagementDbContext(DbContextOptions<HospitalManagementDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorDetail> DoctorDetails { get; set; }

        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
             
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<StaffDetail> StaffDetails { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }

    }
}
