using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eKlinika.Services.Migrations
{
    /// <inheritdoc />
    public partial class addForPacijentAndLjekarId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrijemPacijenta_Ljekari_NadlezniLjekarId",
                table: "PrijemPacijenta");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijemPacijenta_Pacijenti_PacijentId",
                table: "PrijemPacijenta");

            migrationBuilder.AlterColumn<int>(
                name: "PacijentId",
                table: "PrijemPacijenta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NadlezniLjekarId",
                table: "PrijemPacijenta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijemPacijenta_Ljekari_NadlezniLjekarId",
                table: "PrijemPacijenta",
                column: "NadlezniLjekarId",
                principalTable: "Ljekari",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijemPacijenta_Pacijenti_PacijentId",
                table: "PrijemPacijenta",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrijemPacijenta_Ljekari_NadlezniLjekarId",
                table: "PrijemPacijenta");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijemPacijenta_Pacijenti_PacijentId",
                table: "PrijemPacijenta");

            migrationBuilder.AlterColumn<int>(
                name: "PacijentId",
                table: "PrijemPacijenta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NadlezniLjekarId",
                table: "PrijemPacijenta",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijemPacijenta_Ljekari_NadlezniLjekarId",
                table: "PrijemPacijenta",
                column: "NadlezniLjekarId",
                principalTable: "Ljekari",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijemPacijenta_Pacijenti_PacijentId",
                table: "PrijemPacijenta",
                column: "PacijentId",
                principalTable: "Pacijenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
