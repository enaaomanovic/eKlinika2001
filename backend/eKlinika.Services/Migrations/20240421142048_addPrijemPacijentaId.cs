using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eKlinika.Services.Migrations
{
    /// <inheritdoc />
    public partial class addPrijemPacijentaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HitniPrijem",
                table: "PrijemPacijenta",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "PrijemPacijentaId",
                table: "Nalazi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nalazi_PrijemPacijentaId",
                table: "Nalazi",
                column: "PrijemPacijentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nalazi_PrijemPacijenta_PrijemPacijentaId",
                table: "Nalazi",
                column: "PrijemPacijentaId",
                principalTable: "PrijemPacijenta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nalazi_PrijemPacijenta_PrijemPacijentaId",
                table: "Nalazi");

            migrationBuilder.DropIndex(
                name: "IX_Nalazi_PrijemPacijentaId",
                table: "Nalazi");

            migrationBuilder.DropColumn(
                name: "PrijemPacijentaId",
                table: "Nalazi");

            migrationBuilder.AlterColumn<bool>(
                name: "HitniPrijem",
                table: "PrijemPacijenta",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
