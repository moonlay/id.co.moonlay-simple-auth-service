using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class RepairPayrollAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Payrolls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Payrolls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullNameEmployeeAsset",
                table: "Assets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "FullNameEmployeeAsset",
                table: "Assets");
        }
    }
}
