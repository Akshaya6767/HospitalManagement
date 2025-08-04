using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HospitalManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> Register([FromBody] RegistrationDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var registration = await _registrationService.RegisterAsync(dto);
            return CreatedAtAction(nameof(GetByPhoneNumber), new { phoneNumber = registration.PhoneNumber }, registration);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<ActionResult<Registration>> GetByPhoneNumber(string phoneNumber)
        {
            var registration = await _registrationService.GetByPhoneNumberAsync(phoneNumber);
            if (registration == null)
                return NotFound();
            return Ok(registration);
        }
    }
}
