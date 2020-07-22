using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class UpdateWorkingExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "WorkingExperiences",
                newName: "TanggalSelesai");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "WorkingExperiences",
                newName: "TanggalMulai");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "WorkingExperiences",
                newName: "Deskripsi");

            migrationBuilder.RenameColumn(
                name: "Certificate",
                table: "WorkingExperiences",
                newName: "Sertifikat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TanggalSelesai",
                table: "WorkingExperiences",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "TanggalMulai",
                table: "WorkingExperiences",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "Sertifikat",
                table: "WorkingExperiences",
                newName: "Certificate");

            migrationBuilder.RenameColumn(
                name: "Deskripsi",
                table: "WorkingExperiences",
                newName: "Description");
        }
    }
}
