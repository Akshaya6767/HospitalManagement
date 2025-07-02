using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Services.Service;
using Microsoft.AspNetCore.Mvc;
using HospitalManagement.Services.Interface;

namespace HospitalManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeSlotController : ControllerBase
    {
        private readonly ITimeSlotService _service;

        public TimeSlotController(ITimeSlotService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public IActionResult Create(TimeSlotDTO dto)
        {
            _service.Add(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.SlotCode }, dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TimeSlotDTO dto)
        {
            if (id != dto.SlotCode) return BadRequest();
            _service.Update(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}


