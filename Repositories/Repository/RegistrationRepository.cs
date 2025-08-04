using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repositories.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly HospitalManagementDbContext _context;
        public RegistrationRepository(HospitalManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Registration> RegisterAsync(Registration registration)
        {
            await _context.Set<Registration>().AddAsync(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<Registration> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Set<Registration>().FirstOrDefaultAsync(r => r.PhoneNumber == phoneNumber);
        }
    }
}
