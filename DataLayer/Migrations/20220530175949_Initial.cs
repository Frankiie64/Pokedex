using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPokemones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPokemones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdRegion = table.Column<int>(type: "int", nullable: false),
                    IdHabilidadPrincipal = table.Column<int>(type: "int", nullable: false),
                    IdHabilidadSecundaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemones_Regiones_IdRegion",
                        column: x => x.IdRegion,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_TipoPokemones_IdHabilidadPrincipal",
                        column: x => x.IdHabilidadPrincipal,
                        principalTable: "TipoPokemones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemones_TipoPokemones_IdHabilidadSecundaria",
                        column: x => x.IdHabilidadSecundaria,
                        principalTable: "TipoPokemones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IdHabilidadPrincipal",
                table: "Pokemones",
                column: "IdHabilidadPrincipal");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IdHabilidadSecundaria",
                table: "Pokemones",
                column: "IdHabilidadSecundaria");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemones_IdRegion",
                table: "Pokemones",
                column: "IdRegion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemones");

            migrationBuilder.DropTable(
                name: "Regiones");

            migrationBuilder.DropTable(
                name: "TipoPokemones");
        }
    }
}
