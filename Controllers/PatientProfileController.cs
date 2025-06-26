using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Services.Interface;
using HospitalManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class PatientProfileController : ControllerBase
    {
        private readonly IPatientProfileService _patientProfileService;
        
    
        public PatientProfileController(HospitalManagementDbContext context, IPatientProfileService patientProfileService)
        {
            _patientProfileService = patientProfileService;
        }

       

        
    }
}
