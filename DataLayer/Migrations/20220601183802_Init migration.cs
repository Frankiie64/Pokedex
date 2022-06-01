using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Initmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_TipoPokemones_IdHabilidadSecundaria",
                table: "Pokemones");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_TipoPokemones_IdHabilidadSecundaria",
                table: "Pokemones",
                column: "IdHabilidadSecundaria",
                principalTable: "TipoPokemones",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemones_TipoPokemones_IdHabilidadSecundaria",
                table: "Pokemones");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemones_TipoPokemones_IdHabilidadSecundaria",
                table: "Pokemones",
                column: "IdHabilidadSecundaria",
                principalTable: "TipoPokemones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
