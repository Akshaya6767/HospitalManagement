using HospitalManagement.DTOs;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Services.Interface
{
    public interface IDoctorDetailsService
    {
        Task<DoctorDetail> AddDocDetailAsync(DoctorDetailDTO doctorDetailDto);
        Task<IEnumerable<DoctorDetail>> GetAllDocDetailAsync();
        Task <DoctorDetail> GetDocDetailByNameAsync(string DoctorName);
        Task DeleteDocDetailsAsync(int DoctorId);
        Task UpdateDoctorDetailAsync(int doctorId, DoctorDetail doctorDetail);
        

    }
}
