using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class Profile_Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "AccountProfiles",
                newName: "WorkingEXP");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "AccountProfiles",
                newName: "SkillSet");

            migrationBuilder.AddColumn<string>(
                name: "JobStatus",
                table: "Permissions",
                maxLength: 225,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssetID",
                table: "AccountProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CoorporateEmail",
                table: "AccountProfiles",
                maxLength: 225,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "AccountProfiles",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationHistory",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContact",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyData",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfromalEducationHistory",
                table: "AccountProfiles",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitleName",
                table: "AccountProfiles",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "JoinDate",
                table: "AccountProfiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AccountProfiles",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayrollID",
                table: "AccountProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Religion",
                table: "AccountProfiles",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AccountProfiles",
                maxLength: 25,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assets",
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
                    AssetID = table.Column<int>(nullable: false),
                    AssetNumber = table.Column<int>(nullable: false),
                    AssetType = table.Column<string>(maxLength: 255, nullable: true),
                    AssetName = table.Column<string>(maxLength: 255, nullable: true),
                    AcquisitionDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationInfos",
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
                    no = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(maxLength: 25, nullable: true),
                    Institution = table.Column<string>(maxLength: 225, nullable: true),
                    Majors = table.Column<string>(maxLength: 255, nullable: true),
                    YearStart = table.Column<int>(nullable: false),
                    YearEnd = table.Column<int>(nullable: false),
                    HeldBy = table.Column<string>(maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    Fee = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Certificate = table.Column<bool>(nullable: false),
                    Company = table.Column<string>(maxLength: 255, nullable: true),
                    JobPosition = table.Column<string>(maxLength: 255, nullable: true),
                    FromJob = table.Column<string>(maxLength: 255, nullable: true),
                    ToJob = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDatas",
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
                    FullNameOfFamily = table.Column<string>(maxLength: 255, nullable: true),
                    Relationship = table.Column<string>(maxLength: 20, nullable: true),
                    DOBFamily = table.Column<DateTimeOffset>(nullable: true),
                    Religion = table.Column<string>(maxLength: 15, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    KTPNumber = table.Column<string>(maxLength: 255, nullable: true),
                    No = table.Column<int>(nullable: false),
                    NameOfContact = table.Column<string>(maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
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
                    PayrollID = table.Column<int>(nullable: false),
                    Salary = table.Column<string>(maxLength: 255, nullable: true),
                    Tax = table.Column<string>(maxLength: 255, nullable: true),
                    BPJSKesehatan = table.Column<string>(maxLength: 255, nullable: true),
                    BPJSTenagaKerja = table.Column<string>(maxLength: 255, nullable: true),
                    NPWP = table.Column<string>(maxLength: 255, nullable: true),
                    NameBankAccount = table.Column<string>(maxLength: 255, nullable: true),
                    Bank = table.Column<string>(maxLength: 15, nullable: true),
                    BankAccountNumber = table.Column<string>(maxLength: 255, nullable: true),
                    BankBranch = table.Column<string>(maxLength: 255, nullable: true),
                    BackDatedPayment = table.Column<DateTimeOffset>(nullable: false),
                    Allowance = table.Column<string>(maxLength: 255, nullable: true),
                    Incentive = table.Column<string>(maxLength: 255, nullable: true),
                    PaidLeave = table.Column<string>(maxLength: 255, nullable: true),
                    SalaryPeriod = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "EducationInfos");

            migrationBuilder.DropTable(
                name: "FamilyDatas");

            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropColumn(
                name: "JobStatus",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "AssetID",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "CoorporateEmail",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "EducationHistory",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "EmergencyContact",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "FamilyData",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "InfromalEducationHistory",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "JobTitleName",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "PayrollID",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AccountProfiles");

            migrationBuilder.RenameColumn(
                name: "WorkingEXP",
                table: "AccountProfiles",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "SkillSet",
                table: "AccountProfiles",
                newName: "Firstname");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AccountProfiles",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);
        }
    }
}
