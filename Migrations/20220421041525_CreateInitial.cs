using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoreResults.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RUA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NUMERO = table.Column<int>(type: "int", nullable: true),
                    BAIRRO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIDADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PONTOREFERENCIA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
