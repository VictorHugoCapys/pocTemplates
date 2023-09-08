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
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    idade = table.Column<int>(type: "INTEGER", nullable: false),
                    altura = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDeDados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VariaveisTemplates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    identificador = table.Column<string>(type: "TEXT", nullable: false),
                    operacao = table.Column<string>(type: "TEXT", nullable: false),
                    modulo = table.Column<string>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariaveisTemplates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TabelaDeDados2",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    telefone = table.Column<string>(type: "TEXT", nullable: false),
                    idDados = table.Column<int>(type: "INTEGER", nullable: false),
                    TabelaDeDadoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaDeDados2", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TabelaDeDados2_TabelaDeDados_TabelaDeDadoID",
                        column: x => x.TabelaDeDadoID,
                        principalTable: "TabelaDeDados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabelaDeDados2_TabelaDeDadoID",
                table: "TabelaDeDados2",
                column: "TabelaDeDadoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaDeDados2");

            migrationBuilder.DropTable(
                name: "VariaveisTemplates");

            migrationBuilder.DropTable(
                name: "TabelaDeDados");
        }
    }
}
