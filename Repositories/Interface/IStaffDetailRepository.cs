using HospitalManagement.Models;

namespace HospitalManagement.Repositories
{
    public interface IStaffDetailRepository
    {
        Task<IEnumerable<StaffDetail>> GetAllAsync();
        Task<StaffDetail?> GetByIdAsync(int id);
        Task<IEnumerable<StaffDetail>> GetByNameAsync(string name);
        Task<StaffDetail> AddAsync(StaffDetail staff);
        Task<StaffDetail?> UpdateAsync(int id, StaffDetail staff);
        Task<bool> DeleteAsync(int id);
    }
}

