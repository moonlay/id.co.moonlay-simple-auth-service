using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class AccountProfileMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "No",
                table: "FamilyDatas",
                newName: "FamilyId");

            migrationBuilder.RenameColumn(
                name: "no",
                table: "EducationInfos",
                newName: "EducationInfoId");

            migrationBuilder.AddColumn<int>(
                name: "EducationInfoId",
                table: "AccountProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FamilyId",
                table: "AccountProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_AssetID",
                table: "AccountProfiles",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_EducationInfoId",
                table: "AccountProfiles",
                column: "EducationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_FamilyId",
                table: "AccountProfiles",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_PayrollID",
                table: "AccountProfiles",
                column: "PayrollID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_Assets_AssetID",
                table: "AccountProfiles",
                column: "AssetID",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_EducationInfos_EducationInfoId",
                table: "AccountProfiles",
                column: "EducationInfoId",
                principalTable: "EducationInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_FamilyDatas_FamilyId",
                table: "AccountProfiles",
                column: "FamilyId",
                principalTable: "FamilyDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_Payrolls_PayrollID",
                table: "AccountProfiles",
                column: "PayrollID",
                principalTable: "Payrolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Assets_AssetID",
                table: "AccountProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_EducationInfos_EducationInfoId",
                table: "AccountProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_FamilyDatas_FamilyId",
                table: "AccountProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Payrolls_PayrollID",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_AssetID",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_EducationInfoId",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_FamilyId",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_PayrollID",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "EducationInfoId",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "AccountProfiles");

            migrationBuilder.RenameColumn(
                name: "FamilyId",
                table: "FamilyDatas",
                newName: "No");

            migrationBuilder.RenameColumn(
                name: "EducationInfoId",
                table: "EducationInfos",
                newName: "no");
        }
    }
}
