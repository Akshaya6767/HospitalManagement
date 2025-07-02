using HospitalManagement.Models;
using HospitalManagement.Repositories;

namespace HospitalManagement.Services
{
    public class StaffDetailService : IStaffDetailService
    {
        private readonly IStaffDetailRepository _repository;

        public StaffDetailService(IStaffDetailRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<StaffDetail>> GetAllAsync() => _repository.GetAllAsync();
        public Task<StaffDetail?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task<IEnumerable<StaffDetail>> GetByNameAsync(string name) => _repository.GetByNameAsync(name);
        public Task<StaffDetail> AddAsync(StaffDetail staff) => _repository.AddAsync(staff);
        public Task<StaffDetail?> UpdateAsync(int id, StaffDetail staff) => _repository.UpdateAsync(id, staff);
        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

