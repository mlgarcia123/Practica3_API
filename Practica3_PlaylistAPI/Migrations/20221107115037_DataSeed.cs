using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practica3_PlaylistAPI.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cantantes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Rihanna" });

            migrationBuilder.InsertData(
                table: "Cantantes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Beyonce" });

            migrationBuilder.InsertData(
                table: "Cantantes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Maroon 5" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "CantanteId", "Estreno", "Name" },
                values: new object[] { 1, 1, 2007, "Umbrella" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "CantanteId", "Estreno", "Name" },
                values: new object[] { 2, 1, 2012, "Diamonds" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "CantanteId", "Estreno", "Name" },
                values: new object[] { 3, 2, 2008, "Single Ladies" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "CantanteId", "Estreno", "Name" },
                values: new object[] { 4, 2, 2011, "Run the World" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "CantanteId", "Estreno", "Name" },
                values: new object[] { 5, 3, 2017, "Girls Like You" });

            migrationBuilder.InsertData(
                table: "Canciones",
                columns: new[] { "Id", "CantanteId", "Estreno", "Name" },
                values: new object[] { 6, 3, 2015, "Animals" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Canciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Canciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Canciones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Canciones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Canciones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Canciones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cantantes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cantantes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cantantes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
