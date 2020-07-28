using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class RemoveAssetIDPayrollID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Assets_AssetID",
                table: "AccountProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Payrolls_PayrollID",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_AssetID",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_PayrollID",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "AssetID",
                table: "AccountProfiles");

            migrationBuilder.DropColumn(
                name: "PayrollID",
                table: "AccountProfiles");

            migrationBuilder.AddColumn<int>(
                name: "AccountProfileId",
                table: "Payrolls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountProfileId",
                table: "Assets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_AccountProfileId",
                table: "Payrolls",
                column: "AccountProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AccountProfileId",
                table: "Assets",
                column: "AccountProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AccountProfiles_AccountProfileId",
                table: "Assets",
                column: "AccountProfileId",
                principalTable: "AccountProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_AccountProfiles_AccountProfileId",
                table: "Payrolls",
                column: "AccountProfileId",
                principalTable: "AccountProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AccountProfiles_AccountProfileId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_AccountProfiles_AccountProfileId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_AccountProfileId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Assets_AccountProfileId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AccountProfileId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "AccountProfileId",
                table: "Assets");

            migrationBuilder.AddColumn<int>(
                name: "AssetID",
                table: "AccountProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayrollID",
                table: "AccountProfiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_AssetID",
                table: "AccountProfiles",
                column: "AssetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_PayrollID",
                table: "AccountProfiles",
                column: "PayrollID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountProfiles_Assets_AssetID",
                table: "AccountProfiles",
                column: "AssetID",
                principalTable: "Assets",
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
