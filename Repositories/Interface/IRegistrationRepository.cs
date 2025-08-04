using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.Repositories.Interface
{
    public interface IRegistrationRepository
    {
        Task<Registration> RegisterAsync(Registration registration);
        Task<Registration> GetByPhoneNumberAsync(string phoneNumber);
    }
}
