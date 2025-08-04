using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Services.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IPatientProfileRepository _patientProfileRepository;

        public RegistrationService(IRegistrationRepository registrationRepository, IPatientProfileRepository patientProfileRepository)
        {
            _registrationRepository = registrationRepository;
            _patientProfileRepository = patientProfileRepository;
        }

        public async Task<Registration> RegisterAsync(RegistrationDTO dto)
        {
            // Create PatientProfile first to get PatientID
            var patientProfile = new PatientProfile
            {
                PatientName = dto.Name,
                Address = dto.PatientAddress,
                DateOfBirth = dto.DOB,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender
            };
            var createdPatient = await _patientProfileRepository.AddPatientProfileAsync(patientProfile);

            // Generate username as Name + PatientID
            var username = $"{dto.Name}{createdPatient.PatientID}";

            var hashedPassword = HashPassword(dto.Password);
            var registration = new Registration
            {
                Name = dto.Name,
                PatientAddress = dto.PatientAddress,
                DOB = dto.DOB,
                PhoneNumber = dto.PhoneNumber,
                Gender = dto.Gender,
                Username = username,
                Role = dto.Role,
                Password = hashedPassword
            };

            return await _registrationRepository.RegisterAsync(registration);
        }

        private string HashPassword(string password)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var hash = System.Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            return hash;
        
        }

        public async Task<Registration> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _registrationRepository.GetByPhoneNumberAsync(phoneNumber);
        }
    }
}
