    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HospitalManagement.Models;
    using HospitalManagement.Repositories.Interface;
    using Microsoft.EntityFrameworkCore;
    
    namespace HospitalManagement.Repositories.Repository
    {
        public class AppointmentRepository : IAppointmentRepository
        {       
                private readonly HospitalManagementDbContext _context;
                
                public AppointmentRepository(HospitalManagementDbContext context)
                {
                    _context = context;
                }
                
                public async Task<Appointment> CreateAsync(Appointment appointment)
                {
                    _context.Appointments.Add(appointment);
                    await _context.SaveChangesAsync();
                    return appointment;
                }

                public async Task<Appointment?> UpdateAsync(int id, Appointment updated)
                {
                    var existing = await _context.Appointments.FindAsync(id);
                    if (existing == null) return null;

                    existing.AppointmentDate = updated.AppointmentDate;
                    existing.Slot = updated.Slot;
                    existing.Speciality = updated.Speciality;
                    existing.ConsultationVenue = updated.ConsultationVenue;
                    existing.Concern = updated.Concern;
                    existing.Status = updated.Status;

                    await _context.SaveChangesAsync();
                    return existing;
                }

                public async Task<bool> DeleteAsync(int id)
                {
                    var appt = await _context.Appointments.FindAsync(id);
                    if (appt == null) return false;

                    _context.Appointments.Remove(appt);
                    await _context.SaveChangesAsync();
                    return true;
                }

                public async Task<IEnumerable<Appointment>> GetAllAsync() =>
                    await _context.Appointments.ToListAsync();

                public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId) =>
                    await _context.Appointments.Where(a => a.DoctorID == doctorId).ToListAsync();

                public async Task<IEnumerable<Appointment>> GetUpcomingByPatientAsync(string phoneNumber)
                {
                    return await _context.Appointments
                        .Where(a => a.PhoneNumber == phoneNumber && a.AppointmentDate >= DateOnly.FromDateTime(DateTime.Today))
                        .ToListAsync();
                }

                public async Task<Appointment?> GetByIdAsync(int id) =>
                        await _context.Appointments.FindAsync(id);
        }
    }

