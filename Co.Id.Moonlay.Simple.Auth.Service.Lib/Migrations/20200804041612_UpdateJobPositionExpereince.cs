using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class UpdateJobPositionExpereince : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobPosition",
                table: "WorkingExperiences",
                newName: "JobPositionExperience");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobPositionExperience",
                table: "WorkingExperiences",
                newName: "JobPosition");
        }
    }
}
