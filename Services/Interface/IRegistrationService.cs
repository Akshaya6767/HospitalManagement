using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;

namespace HospitalManagement.Services.Interface
{
    public interface IRegistrationService
    {
        Task<Registration> RegisterAsync(RegistrationDTO dto);
        Task<Registration> GetByPhoneNumberAsync(string phoneNumber);
    }
}
