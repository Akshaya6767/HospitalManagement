using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Repositories.Interface
{
    public interface IDoctorDetailsRepository
    {
        Task<DoctorDetail> AddDocDetailAsync(DoctorDetail doctorDetail);
        Task<IEnumerable<DoctorDetail>> GetAllDocDetailAsync();
        Task <DoctorDetail> GetDocDetailByNameAsync(string DoctorName);
        Task DeleteDocDetailsAsync(int DoctorId);
        Task UpdateDoctorDetailAsync(int doctorId, [FromBody] DoctorDetail doctorDetail);
        Task<IEnumerable<DoctorDetail>> GetDocDetailByIdAndNameAsync(int doctorId, string doctorName);


    }
}
