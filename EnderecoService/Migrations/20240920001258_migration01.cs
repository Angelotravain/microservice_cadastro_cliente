using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnderecoService.Migrations
{
    public partial class migration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LOGRADOURO = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BAIRRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CIDADE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CLIENTE_ID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
