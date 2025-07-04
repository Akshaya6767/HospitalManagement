﻿using System.ComponentModel.DataAnnotations;
using HospitalManagement.DTOs;
using HospitalManagement.Models;
using HospitalManagement.Services.Interface;
using HospitalManagement.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Services.Service
{
    public class DoctorDetailsService : IDoctorDetailsService
    {
        private readonly IDoctorDetailsRepository _doctorDetailsRepository;

        public DoctorDetailsService(IDoctorDetailsRepository doctorDetailsRepository)
        {
            _doctorDetailsRepository = doctorDetailsRepository;
        }

        public async Task<DoctorDetail> AddDocDetailAsync(DoctorDetailDTO doctorDetailDto)
        {
            var doctorDetail = new DoctorDetail
            {
                //DoctorId = doctorDetailDto.DoctorId,
                DoctorName = doctorDetailDto.DoctorName,
                ConsultationVenue = doctorDetailDto.ConsultationVenue,
                Qualification = doctorDetailDto.Qualification,
                Speciality = doctorDetailDto.Speciality,
            };
            return await _doctorDetailsRepository.AddDocDetailAsync(doctorDetail);
        }

        public async Task<IEnumerable<DoctorDetail>> GetAllDocDetailAsync()
        {
            return await _doctorDetailsRepository.GetAllDocDetailAsync();
        }

        public async Task<DoctorDetail> GetDocDetailByNameAsync(string DoctorName)
        {
            return await _doctorDetailsRepository.GetDocDetailByNameAsync(DoctorName);
        }

        public async Task DeleteDocDetailsAsync(int DoctorId)
        {
            await _doctorDetailsRepository.DeleteDocDetailsAsync(DoctorId);

        }
        public async Task UpdateDoctorDetailAsync(int doctorId, DoctorDetail doctorDetail)
        {
            var updatedocdetail = new DoctorDetail
            {
                DoctorName = doctorDetail.DoctorName,
                ConsultationVenue = doctorDetail.ConsultationVenue,
                Qualification = doctorDetail.Qualification,
                Speciality = doctorDetail.Speciality,
            };
            await _doctorDetailsRepository.UpdateDoctorDetailAsync(doctorId, updatedocdetail);
        }


    }
}
