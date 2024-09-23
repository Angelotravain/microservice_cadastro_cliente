using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClienteService.Migrations
{
    public partial class migration04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "CLIENTE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTE",
                table: "CLIENTE",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTE",
                table: "CLIENTE");

            migrationBuilder.RenameTable(
                name: "CLIENTE",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "ID");
        }
    }
}
