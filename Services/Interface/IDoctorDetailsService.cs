using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IDoctorDetailsService
    {
        Task<DoctorDetail> AddDocDetailAsync(DoctorDetailDTO doctorDetailDto);
        Task<IEnumerable<DoctorDetail>> GetAllDocDetailAsync();
        Task <DoctorDetail> GetDocDetailByNameAsync(string DoctorName);
        Task DeleteDocDetailsAsync(int DoctorId);
    }
}
