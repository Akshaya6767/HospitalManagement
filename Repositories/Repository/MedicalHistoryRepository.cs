using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories.Repository
{
    public class MedicalHistoryRepository : IMedicalHistoryRepository
    {
        private readonly HospitalManagementDbContext _context;

        public MedicalHistoryRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<MedicalHistory> AddMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            await _context.MedicalHistories.AddAsync(medicalHistory);
            await _context.SaveChangesAsync();
            return medicalHistory;
        }

        public async Task<IEnumerable<MedicalHistory>> GetAllMedicalHistoriesAsync()
        {
            return await _context.MedicalHistories.ToListAsync();
        }

        public async Task<MedicalHistory> GetMedicalHistoryByIdAsync(int historyID)
        {
            return await _context.MedicalHistories.FindAsync(historyID);
        }

        public async Task UpdateMedicalHistoryAsync(MedicalHistory medicalHistory)
        {
            _context.Entry(medicalHistory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
