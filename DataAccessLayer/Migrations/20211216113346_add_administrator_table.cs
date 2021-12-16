using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class add_administrator_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministartorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministartorUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministartorPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministartorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministartorShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministartorImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdministartorRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministartorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");
        }
    }
}
