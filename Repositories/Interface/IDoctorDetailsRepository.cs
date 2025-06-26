using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface IDoctorDetailsRepository
    {
        Task<DoctorDetail> AddDocDetailAsync(DoctorDetail doctorDetail);
        Task<IEnumerable<DoctorDetail>> GetAllDocDetailAsync();
        Task <DoctorDetail> GetDocDetailByNameAsync(string DoctorName);
        Task DeleteDocDetailsAsync(int DoctorId);
        Task UpdateDoctorDetailAsync(int doctorId, DoctorDetail doctorDetail);

    }
}
