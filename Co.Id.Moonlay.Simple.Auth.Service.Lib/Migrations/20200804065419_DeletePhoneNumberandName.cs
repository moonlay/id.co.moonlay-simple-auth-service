using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class DeletePhoneNumberandName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "FamilyDatas");

            migrationBuilder.DropColumn(
                name: "NameOfContact",
                table: "FamilyDatas");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "FamilyDatas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "FamilyDatas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NameOfContact",
                table: "FamilyDatas",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "FamilyDatas",
                maxLength: 255,
                nullable: true);
        }
    }
}
