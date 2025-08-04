using HospitalManagement;
using HospitalManagement.Repositories;
using HospitalManagement.Repositories.Interface;
using HospitalManagement.Repositories.Repository;
using HospitalManagement.Services;
using HospitalManagement.Services.Interface;
using HospitalManagement.Services.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using System.Text;

namespace HospitalManagement
{
    public class Program
    {


        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<HospitalManagementDbContext>(options => options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));

            
            builder.Services.AddControllers();

            // JWT Authentication configuration
            var jwtKey = builder.Configuration["Jwt:Key"] ?? "SuperSecretKeyForJwtToken12345!";
            var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "HospitalSystem";
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            builder.Services.AddScoped<IDoctorDetailsRepository, DoctorDetailsRepository>();
            builder.Services.AddScoped<IDoctorDetailsService, DoctorDetailsService>();
            builder.Services.AddScoped<IPatientProfileRepository, PatientProfileRepository>();
            builder.Services.AddScoped<IPatientProfileService, PatientProfileService>();
            builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            builder.Services.AddScoped<IRegistrationService, RegistrationService>();
            builder.Services.AddScoped<IStaffDetailRepository, StaffDetailRepository>();
            builder.Services.AddScoped<IStaffDetailService, StaffDetailService>();
            builder.Services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            builder.Services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
            builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();
            builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
            builder.Services.AddScoped<IDoctorScheduleService, DoctorScheduleService>();
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddScoped<IAppointmentService,AppointmentService>();



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital Management", Version = "v1" });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAngularApp");

            //app.UseCors("AllowAllOrigins");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }

    }
}


