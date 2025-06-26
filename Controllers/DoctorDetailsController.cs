using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagement;
using HospitalManagement.Models;
using HospitalManagement.DTOs;
using HospitalManagement.Services.Interface;

namespace HospitalSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorDetailsController : ControllerBase
    {
        private readonly IDoctorDetailsService _doctorDetailsService;

        public DoctorDetailsController(IDoctorDetailsService doctorDetailsService)
        {
            _doctorDetailsService = doctorDetailsService;
        }

        [HttpPost]
        [Route("api/doctorDetail")]
        public async Task<ActionResult<DoctorDetail>> PostDoctorDetail(DoctorDetailDTO doctorDetaildto)
        {
            var createdDocDet = await _doctorDetailsService.AddDocDetailAsync(doctorDetaildto);

            return (createdDocDet);
        }

        [HttpGet]
        [Route("api/doctorDetail")]
        public async Task<ActionResult<IEnumerable<DoctorDetail>>> GetAllDocDetails()
        {
            var docDetails = await _doctorDetailsService.GetAllDocDetailAsync();
            return Ok(docDetails);
        }

        [HttpGet("{DoctorName}")]
        public async Task<ActionResult<DoctorDetail>> GetDocDetailByNameAsync(string DoctorName)
        {
            var dd = await _doctorDetailsService.GetDocDetailByNameAsync(DoctorName);
            if (dd == null)
            {
                return NotFound();
            }
            return Ok(dd);
        }

        [HttpDelete("{DoctorId}")]
        public async Task<IActionResult> DeleteDocDetailsAsync(int DoctorId)
        {
            try
            {
                await _doctorDetailsService.DeleteDocDetailsAsync(DoctorId);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{DoctorId}")]

        public async Task<IActionResult> GetDocDetailsAsync(int doctorId, DoctorDetail doctorDetail)
        {
            if (doctorId != doctorDetail.DoctorId)
            {
                return BadRequest();
            }
            try
            {
                await _doctorDetailsService.UpdateDoctorDetailAsync(doctorId, doctorDetail);
            }

            catch(KeyNotFoundException)
            {
                return NotFound();
            }
            return NoContent();
        }
        
    }
}
