using System.Collections.Generic;
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
    public class MedicalHistoryController : ControllerBase
    {
        private readonly IMedicalHistoryService _medicalHistoryService;

        public MedicalHistoryController(IMedicalHistoryService medicalHistoryService)
        {
            _medicalHistoryService = medicalHistoryService;
        }

        [HttpPost]
        public async Task<ActionResult<MedicalHistoryDTO>> PostMedicalHistory(MedicalHistoryDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var medicalHistory = new MedicalHistory
            {
                Diagnosis = dto.Diagnosis,
                Treatment = dto.Treatment,
                DateOfVisit = dto.DateOfVisit,
                
            };

            var created = await _medicalHistoryService.AddMedicalHistoryAsync(medicalHistory);

            var result = new MedicalHistoryDTO
            {
                HistoryID = created.HistoryID,
                Diagnosis = created.Diagnosis,
                Treatment = created.Treatment,
                DateOfVisit = created.DateOfVisit
            };

            return CreatedAtAction(nameof(GetMedicalHistoryById), new { historyID = result.HistoryID }, result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalHistory>>> GetAllMedicalHistories()
        {
            var medicalHistories = await _medicalHistoryService.GetAllMedicalHistoriesAsync();
            return Ok(medicalHistories);
        }

        [HttpGet("{historyID}")]
        public async Task<ActionResult<MedicalHistory>> GetMedicalHistoryById(int historyID)
        {
            var medicalHistory = await _medicalHistoryService.GetMedicalHistoryByIdAsync(historyID);
            if (medicalHistory == null)
            {
                return NotFound();
            }
            return Ok(medicalHistory);
        }

        [HttpPut("{historyID}")]
        public async Task<IActionResult> UpdateMedicalHistory(int historyID, MedicalHistory medicalHistory)
        {
            if (historyID != medicalHistory.HistoryID)
            {
                return BadRequest("The historyID does not match the HistoryID in the provided details.");
            }

            try
            {
                await _medicalHistoryService.UpdateMedicalHistoryAsync(medicalHistory);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating medical history: {ex.Message}");
            }
        }
    }
}


