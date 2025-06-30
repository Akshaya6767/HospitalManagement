using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffDetailController : ControllerBase
    {
        private readonly IStaffDetailService _staffDetailService;
        private readonly ILogger<StaffDetailController> _logger;

        public StaffDetailController(IStaffDetailService staffDetailService, ILogger<StaffDetailController> logger)
        {
            _staffDetailService = staffDetailService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffDetail>>> GetAllStaff()
        {
            var staffdet = await _staffDetailService.GetAllStaffDetailAsync();
            return Ok(staffdet);
        }

        [HttpGet("{staffName}")]
        public async Task<ActionResult<StaffDetail>> GetStaffDetailByNameAsync(string staffName)
        {
            var staffDetail = await _staffDetailService.GetStaffDetailByNameAsync(staffName);
            if (staffDetail == null)
            {
                return NotFound();
            }
            return Ok(staffDetail);
        }

        [HttpPost]
        public async Task<ActionResult<StaffDetail>> PostStaffDetail(StaffDetail staffDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdStaffDetail = await _staffDetailService.AddStaffDetailAsync(staffDetail);
                return CreatedAtAction(nameof(GetStaffDetailByNameAsync), new { staffName = createdStaffDetail.StaffName }, createdStaffDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating staff detail.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{staffID}")]
        public async Task<IActionResult> DeleteStaffDetailsAsync(int staffID)
        {
            try
            {
                await _staffDetailService.DeleteStaffDetailsAsync(staffID);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting staff detail.");
                return BadRequest($"Error deleting staff details: {ex.Message}");
            }
        }

        [HttpGet("byIdAndName")]
        public async Task<ActionResult<StaffDetail>> GetStaffDetailByIdAndNameAsync(int staffId, string staffName)
        {
            var staffDetail = await _staffDetailService.GetStaffDetailByIdAndNameAsync(staffId, staffName);
            if (staffDetail == null)
            {
                return NotFound();
            }
            return Ok(staffDetail);
        }

        [HttpPut("{staffId}")]
        public async Task<IActionResult> UpdateStaffDetailAsync(int staffId, [FromBody] StaffDetail staffDetail)
        {
            if (staffId != staffDetail.StaffID)
            {
                return BadRequest("The staffId does not match the StaffID in the provided details.");
            }
            try
            {
                await _staffDetailService.UpdateStaffDetailAsync(staffId, staffDetail);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating staff detail.");
                return BadRequest($"Error updating staff details: {ex.Message}");
            }
        }
    }
}

