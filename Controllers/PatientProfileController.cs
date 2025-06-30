using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Services.Interface;
using HospitalManagement.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientProfileController : ControllerBase
    {
        private readonly IPatientProfileService _patientProfileService;
      
        public PatientProfileController(HospitalManagementDbContext context, IPatientProfileService patientProfileService)
        {
            _patientProfileService = patientProfileService;
        }

        [HttpPost]
        public async Task<ActionResult<PatientProfile>> PostPatientProfile(PatientProfileDTO patientProfiledto)
        {
            var createdPatientProfile = await _patientProfileService.AddPatientProfileAsync(patientProfiledto);

            return (createdPatientProfile);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientProfile>>> GetAllPatientProfiles()
        {
            var patientProfiles = await _patientProfileService.GetAllPatientProfileAsync();
            return Ok(patientProfiles);
        }


        [HttpGet("{PatientID}")]
        public async Task<ActionResult<PatientProfile>> GetPatientProfileByIdAsync(int PatientID)
        {
            var patientProfile = await _patientProfileService.GetPatientProfileByIdAsync(PatientID);
            if (patientProfile == null)
            {
                return NotFound();
            }
            return Ok(patientProfile);
        }


        [HttpDelete("{PatientID}")]
        public async Task<IActionResult> DeletePatientProfileAsync(int PatientID)
        {
            try
            {
                await _patientProfileService.DeletePatientProfileAsync(PatientID);
               
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
        
        

        [HttpPut("{PatientID}")]
        public async Task<ActionResult> GetPatientProfileByIdAsync(int patientID, PatientProfileDTO patientProfiledto)
        {
            if (patientID != patientProfiledto.PatientID)
            {
                return BadRequest("Patient ID mismatch.");
            }
            try
            {
                await _patientProfileService.UpdatePatientProfileAsync(patientID, patientProfiledto);
                
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return BadRequest("Error updating patient profile");
            
        }



    }
}
