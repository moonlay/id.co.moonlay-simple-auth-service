using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class RemovePayrollAseet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Assets_AssetId",
                table: "AccountProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountProfiles_Payrolls_PayrollId",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_AssetId",
                table: "AccountProfiles");

            migrationBuilder.DropIndex(
                name: "IX_AccountProfiles_PayrollId",
                table: "AccountProfiles");

            migrationBuilder.RenameColumn(
                name: "PayrollId",
                table: "AccountProfiles",
                newName: "PayrollID");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "AccountProfiles",
                newName: "AssetID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PayrollID",
                table: "AccountProfiles",
                newName: "PayrollId");

            migrationBuilder.RenameColumn(
                name: "AssetID",
                table: "AccountProfiles",
                newName: "AssetId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_AssetId",
                table: "AccountProfiles",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountProfiles_PayrollId",
                table: "AccountProfiles",
                column: "PayrollId");

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
    }
}
