using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class update_administrator_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdministartorUserName",
                table: "Administrators",
                newName: "AdministratorUserName");

            migrationBuilder.RenameColumn(
                name: "AdministartorShortDescription",
                table: "Administrators",
                newName: "AdministratorShortDescription");

            migrationBuilder.RenameColumn(
                name: "AdministartorRole",
                table: "Administrators",
                newName: "AdministratorRole");

            migrationBuilder.RenameColumn(
                name: "AdministartorPassword",
                table: "Administrators",
                newName: "AdministratorPassword");

            migrationBuilder.RenameColumn(
                name: "AdministartorName",
                table: "Administrators",
                newName: "AdministratorImageUrl");

            migrationBuilder.RenameColumn(
                name: "AdministartorImageUrl",
                table: "Administrators",
                newName: "AdministratorFirstLastName");

            migrationBuilder.RenameColumn(
                name: "AdministartorId",
                table: "Administrators",
                newName: "AdministratorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdministratorUserName",
                table: "Administrators",
                newName: "AdministartorUserName");

            migrationBuilder.RenameColumn(
                name: "AdministratorShortDescription",
                table: "Administrators",
                newName: "AdministartorShortDescription");

            migrationBuilder.RenameColumn(
                name: "AdministratorRole",
                table: "Administrators",
                newName: "AdministartorRole");

            migrationBuilder.RenameColumn(
                name: "AdministratorPassword",
                table: "Administrators",
                newName: "AdministartorPassword");

            migrationBuilder.RenameColumn(
                name: "AdministratorImageUrl",
                table: "Administrators",
                newName: "AdministartorName");

            migrationBuilder.RenameColumn(
                name: "AdministratorFirstLastName",
                table: "Administrators",
                newName: "AdministartorImageUrl");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "Administrators",
                newName: "AdministartorId");
        }
    }
}
