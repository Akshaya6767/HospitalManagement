using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorScheduleController : ControllerBase
    {                   
        private readonly IDoctorScheduleService _service;
            
        public DoctorScheduleController(IDoctorScheduleService service)
        {
            _service = service;
        }

        [HttpGet("Slots")]
        public async Task<IActionResult> GetAvailableSlots() =>
            Ok(await _service.GetAvailableSlotsAsync());

        [HttpPost("DoctorAvailability")]
        public async Task<IActionResult> MarkAvailability([FromBody] DoctorScheduleDTO dto)
        {
            var success = await _service.MarkAvailabilityAsync(dto);
            return success ? Ok("Availability marked.") : BadRequest("Invalid slot or doctor.");
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAvailabilityByDoctor(int doctorId) =>
            Ok(await _service.GetAvailabilityByDoctorAsync(doctorId));
    }
}