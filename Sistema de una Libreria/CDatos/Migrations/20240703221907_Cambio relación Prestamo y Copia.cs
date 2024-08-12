using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class CambiorelaciónPrestamoyCopia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copia_Prestamo_IdPrestamo",
                table: "Copia");

            migrationBuilder.DropIndex(
                name: "IX_Copia_IdPrestamo",
                table: "Copia");

            migrationBuilder.DropColumn(
                name: "IdPrestamo",
                table: "Copia");

            migrationBuilder.AddColumn<int>(
                name: "IdCopia",
                table: "Prestamo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdCopia",
                table: "Prestamo",
                column: "IdCopia");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Copia_IdCopia",
                table: "Prestamo",
                column: "IdCopia",
                principalTable: "Copia",
                principalColumn: "IdCopia",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Copia_IdCopia",
                table: "Prestamo");

            migrationBuilder.DropIndex(
                name: "IX_Prestamo_IdCopia",
                table: "Prestamo");

            migrationBuilder.DropColumn(
                name: "IdCopia",
                table: "Prestamo");

            migrationBuilder.AddColumn<int>(
                name: "IdPrestamo",
                table: "Copia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Copia_IdPrestamo",
                table: "Copia",
                column: "IdPrestamo");

            migrationBuilder.AddForeignKey(
                name: "FK_Copia_Prestamo_IdPrestamo",
                table: "Copia",
                column: "IdPrestamo",
                principalTable: "Prestamo",
                principalColumn: "IdPrestamo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
