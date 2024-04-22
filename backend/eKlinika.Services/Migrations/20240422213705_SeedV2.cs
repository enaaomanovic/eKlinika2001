using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace eKlinika.Services.Migrations
{
    /// <inheritdoc />
    public partial class SeedV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ljekari",
                columns: new[] { "Id", "Ime", "LozinkaHash", "LozinkaSalt", "Prezime", "Sifra", "Titula", "Username" },
                values: new object[,]
                {
                    { 2, "John", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Smith", "JS123", 0, "john" },
                    { 3, "Emily", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Davis", "ED456", 2, "emily" },
                    { 4, "Michael", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Johnson", "MJ789", 0, "michael" },
                    { 5, "Sophia", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Miller", "SM234", 1, "sophia" },
                    { 6, "Daniel", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Brown", "DB567", 0, "daniel" },
                    { 7, "Olivia", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Taylor", "OT890", 2, "olivia" },
                    { 8, "Benjamin", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Anderson", "BA345", 0, "benjamin" },
                    { 9, "Ljekar", new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 }, new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 }, "Ljekar", "BR845", 0, "ljekar" }
                });

            migrationBuilder.InsertData(
                table: "Pacijenti",
                columns: new[] { "Id", "Adresa", "BrojTelefona", "DatumRodjenja", "Ime", "Prezime", "Spol" },
                values: new object[,]
                {
                    { 2, "123 Elm Street", "062123456", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", 0 },
                    { 3, "456 Oak Avenue", "063987654", new DateTime(1985, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", 1 },
                    { 4, "789 Maple Road", "064654321", new DateTime(1978, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Johnson", 0 },
                    { 5, "567 Pine Avenue", "065987654", new DateTime(1983, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Davis", 1 },
                    { 6, "234 Cedar Lane", "066123987", new DateTime(1995, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Brown", 0 },
                    { 7, "890 Birch Street", "067456123", new DateTime(1972, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sophia", "Miller", 1 },
                    { 8, "345 Oak Lane", "068321654", new DateTime(1980, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Wilson", 0 },
                    { 9, "678 Elm Avenue", "069987654", new DateTime(1992, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivia", "Taylor", 1 }
                });

            migrationBuilder.InsertData(
                table: "PrijemPacijenta",
                columns: new[] { "Id", "DatumIVrijemePrijema", "HitniPrijem", "NadlezniLjekarId", "PacijentId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 2 },
                    { 2, new DateTime(2024, 3, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), true, 3, 2 },
                    { 3, new DateTime(2024, 3, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 3 },
                    { 4, new DateTime(2024, 3, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), true, 5, 4 },
                    { 5, new DateTime(2024, 3, 10, 2, 0, 0, 0, DateTimeKind.Unspecified), false, 6, 5 },
                    { 6, new DateTime(2024, 3, 5, 4, 0, 0, 0, DateTimeKind.Unspecified), true, 7, 6 },
                    { 7, new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), false, 8, 7 },
                    { 8, new DateTime(2024, 2, 26, 3, 0, 0, 0, DateTimeKind.Unspecified), true, 9, 8 },
                    { 9, new DateTime(2024, 2, 22, 4, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 4 },
                    { 10, new DateTime(2024, 2, 18, 5, 0, 0, 0, DateTimeKind.Unspecified), true, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Nalazi",
                columns: new[] { "Id", "DatumIVrijemeKreiranja", "PrijemPacijentaId", "TekstualniOpis" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nalaz 1" },
                    { 2, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nalaz 2" },
                    { 3, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Nalaz 3" },
                    { 4, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Nalaz 4" },
                    { 5, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Nalaz 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nalazi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nalazi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nalazi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nalazi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Nalazi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PrijemPacijenta",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ljekari",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pacijenti",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
