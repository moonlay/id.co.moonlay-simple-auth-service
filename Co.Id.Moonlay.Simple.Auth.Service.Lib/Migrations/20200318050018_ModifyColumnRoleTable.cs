using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class ModifyColumnRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Permissions",
                newName: "JobTitleId");

            migrationBuilder.RenameColumn(
                name: "UnitCode",
                table: "Permissions",
                newName: "JobTitleName");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Permissions",
                newName: "JobTitleCode");

            migrationBuilder.RenameColumn(
                name: "Division",
                table: "Permissions",
                newName: "DivisionName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobTitleName",
                table: "Permissions",
                newName: "UnitCode");

            migrationBuilder.RenameColumn(
                name: "JobTitleId",
                table: "Permissions",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "JobTitleCode",
                table: "Permissions",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "DivisionName",
                table: "Permissions",
                newName: "Division");
        }
    }
}
