using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class WorkingEXP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificate",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "FromJob",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "HeldBy",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "JobPosition",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EducationInfos");

            migrationBuilder.DropColumn(
                name: "ToJob",
                table: "EducationInfos");

            migrationBuilder.CreateTable(
                name: "InformalEducations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: false),
                    LastModifiedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedUtc = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 255, nullable: false),
                    DeletedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    HeldBy = table.Column<string>(maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Certificate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformalEducations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(maxLength: 255, nullable: false),
                    LastModifiedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedUtc = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 255, nullable: false),
                    DeletedAgent = table.Column<string>(maxLength: 255, nullable: false),
                    Company = table.Column<string>(maxLength: 255, nullable: true),
                    JobPosition = table.Column<string>(maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Certificate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingExperiences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformalEducations");

            migrationBuilder.DropTable(
                name: "WorkingExperiences");

            migrationBuilder.AddColumn<bool>(
                name: "Certificate",
                table: "EducationInfos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDate",
                table: "EducationInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fee",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromJob",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeldBy",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobPosition",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "EducationInfos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToJob",
                table: "EducationInfos",
                maxLength: 255,
                nullable: true);
        }
    }
}
