using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class UpdateAccountProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_AccountProfiles_EducationInfoId",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_FamilyId",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "EducationInfoId",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "AccountProfiles");

            migrationBuilder.RenameColumn(
                name: "PayrollID",
                table: "AccountProfiles",
                newName: "PayrollId");

            migrationBuilder.RenameColumn(
                name: "AssetID",
                table: "AccountProfiles",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountProfiles_PayrollID",
                table: "AccountProfiles",
                newName: "IX_AccountProfiles_PayrollId");

            migrationBuilder.RenameIndex(
                name: "IX_AccountProfiles_AssetID",
                table: "AccountProfiles",
                newName: "IX_AccountProfiles_AssetId");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollId",
                table: "AccountProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AssetId",
                table: "AccountProfiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_Assets_AssetId",
                table: "AccountProfiles",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_Payrolls_PayrollId",
                table: "AccountProfiles",
                column: "PayrollId",
                principalTable: "Payrolls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Assets_AssetId",
                table: "AccountProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Payrolls_PayrollId",
                table: "AccountProfiles");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "AccountProfiles",
                newName: "PayrollID");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "AccountProfiles",
                newName: "AssetID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountProfiles_PayrollId",
                table: "AccountProfiles",
                newName: "IX_AccountProfiles_PayrollID");

            migrationBuilder.RenameIndex(
                name: "IX_AccountProfiles_AssetId",
                table: "AccountProfiles",
                newName: "IX_AccountProfiles_AssetID");

            migrationBuilder.AlterColumn<int>(
                name: "PayrollID",
                table: "AccountProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssetID",
                table: "AccountProfiles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                name: "IX_AccountProfiles_EducationInfoId",
                table: "AccountProfiles",
                column: "EducationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_FamilyId",
                table: "AccountProfiles",
                column: "FamilyId");

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
    }
}
