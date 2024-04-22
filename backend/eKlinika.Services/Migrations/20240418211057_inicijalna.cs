using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eKlinika.Services.Migrations
{
    /// <inheritdoc />
    public partial class inicijalna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ljekari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titula = table.Column<int>(type: "int", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LozinkaSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ljekari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nalazi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TekstualniOpis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIVrijemeKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalazi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Spol = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrijemPacijenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIVrijemePrijema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    NadlezniLjekarId = table.Column<int>(type: "int", nullable: false),
                    HitniPrijem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijemPacijenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrijemPacijenta_Ljekari_NadlezniLjekarId",
                        column: x => x.NadlezniLjekarId,
                        principalTable: "Ljekari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrijemPacijenta_Pacijenti_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrijemPacijenta_NadlezniLjekarId",
                table: "PrijemPacijenta",
                column: "NadlezniLjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijemPacijenta_PacijentId",
                table: "PrijemPacijenta",
                column: "PacijentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nalazi");

            migrationBuilder.DropTable(
                name: "PrijemPacijenta");

            migrationBuilder.DropTable(
                name: "Ljekari");

            migrationBuilder.DropTable(
                name: "Pacijenti");
        }
    }
}
