using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnderecoService.Migrations
{
    public partial class migration02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TIPO_ENDERECO",
                table: "ENDERECO",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TIPO_ENDERECO",
                table: "ENDERECO");
        }
    }
}
