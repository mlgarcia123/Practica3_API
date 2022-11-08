using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica3_PlaylistAPI.Migrations
{
    public partial class CantanteDBInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cantantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cantantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Estreno = table.Column<int>(type: "INTEGER", nullable: false),
                    CantanteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canciones_Cantantes_CantanteId",
                        column: x => x.CantanteId,
                        principalTable: "Cantantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canciones_CantanteId",
                table: "Canciones",
                column: "CantanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "Cantantes");
        }
    }
}
