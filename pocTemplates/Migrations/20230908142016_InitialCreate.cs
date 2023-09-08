using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pocTemplates.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaDeDados",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    idade = table.Column<int>(type: "INTEGER", nullable: false),
                    altura = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDeDados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VariaveisTemplate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    identificador = table.Column<string>(type: "TEXT", nullable: true),
                    operacao = table.Column<string>(type: "TEXT", nullable: true),
                    modulo = table.Column<string>(type: "TEXT", nullable: true),
                    nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariaveisTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TabelaDeDados2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    telefone = table.Column<string>(type: "TEXT", nullable: true),
                    idDados = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDeDados2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TabelaDeDados2_TabelaDeDados_idDados",
                        column: x => x.idDados,
                        principalTable: "TabelaDeDados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabelaDeDados2_idDados",
                table: "TabelaDeDados2",
                column: "idDados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaDeDados2");

            migrationBuilder.DropTable(
                name: "VariaveisTemplate");

            migrationBuilder.DropTable(
                name: "TabelaDeDados");
        }
    }
}
