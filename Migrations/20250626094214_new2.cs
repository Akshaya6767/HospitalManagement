using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagement.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_PatientProfile_ApptDatesPatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_PatientProfile_PatientID",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientProfile",
                table: "PatientProfile");

            migrationBuilder.RenameTable(
                name: "PatientProfile",
                newName: "PatientProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientProfiles",
                table: "PatientProfiles",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_PatientProfiles_ApptDatesPatientID",
                table: "Appointments",
                column: "ApptDatesPatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_PatientProfiles_PatientID",
                table: "MedicalHistories",
                column: "PatientID",
                principalTable: "PatientProfiles",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_PatientProfiles_ApptDatesPatientID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalHistories_PatientProfiles_PatientID",
                table: "MedicalHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientProfiles",
                table: "PatientProfiles");

            migrationBuilder.RenameTable(
                name: "PatientProfiles",
                newName: "PatientProfile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientProfile",
                table: "PatientProfile",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_PatientProfile_ApptDatesPatientID",
                table: "Appointments",
                column: "ApptDatesPatientID",
                principalTable: "PatientProfile",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalHistories_PatientProfile_PatientID",
                table: "MedicalHistories",
                column: "PatientID",
                principalTable: "PatientProfile",
                principalColumn: "PatientID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
