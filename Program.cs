using HospitalManagement;
using HospitalManagement.Repositories;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Repositories.Repository;
using HospitalManagement.Services;
using HospitalManagement.Services.Interface;
using HospitalManagement.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HospitalSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<HospitalManagementDbContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {

                        builder.AllowAnyOrigin() // Replace with your frontend URL

                               .AllowAnyMethod()

                               .AllowAnyHeader();

                    });

            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDoctorDetailsRepository, DoctorDetailsRepository>();
            builder.Services.AddScoped<IDoctorDetailsService, DoctorDetailsService>();
            builder.Services.AddScoped<IPatientProfileRepository, PatientProfileRepository>();
            builder.Services.AddScoped<IPatientProfileService, PatientProfileService>();
            builder.Services.AddScoped<IStaffDetailRepository, StaffDetailRepository>();
            builder.Services.AddScoped<IStaffDetailService, StaffDetailService>();
            builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
            builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();
            builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
            builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IAppoinmentService,AppointmentService>();



            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>

            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital Management", Version = "v1" });

            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }
}


