using Microsoft.EntityFrameworkCore.Migrations;

namespace Co.Id.Moonlay.Simple.Auth.Service.Lib.Migrations
{
    public partial class RemoveAccountProfileVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
