using HospitalManagement.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffDetailController : ControllerBase
    {
        private readonly IStaffDetailService _service;

        public StaffDetailController(IStaffDetailService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] int? id, [FromQuery] string? name)
        {
            if (id.HasValue)
            {
                var staffById = await _service.GetByIdAsync(id.Value);
                return staffById == null ? NotFound() : Ok(new List<StaffDetail> { staffById });
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                var staffByName = await _service.GetByNameAsync(name);
                return Ok(staffByName);
            }

            return BadRequest("Please provide either 'id' or 'name' as a query parameter.");
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StaffDetail staff)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.AddAsync(staff);
            return CreatedAtAction(nameof(Search), new { id = created.StaffID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StaffDetail staff)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _service.UpdateAsync(id, staff);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}

