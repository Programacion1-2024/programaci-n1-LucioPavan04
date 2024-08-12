using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDatos.Migrations
{
    /// <inheritdoc />
    public partial class CambioderelacionLibroyVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Venta_IdVenta",
                table: "Libro");

            migrationBuilder.DropIndex(
                name: "IX_Libro_IdVenta",
                table: "Libro");

            migrationBuilder.DropColumn(
                name: "IdVenta",
                table: "Libro");

            migrationBuilder.AddColumn<int>(
                name: "IdLibro",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdLibro",
                table: "Venta",
                column: "IdLibro");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Libro_IdLibro",
                table: "Venta",
                column: "IdLibro",
                principalTable: "Libro",
                principalColumn: "IdLibro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Libro_IdLibro",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_IdLibro",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "IdLibro",
                table: "Venta");

            migrationBuilder.AddColumn<int>(
                name: "IdVenta",
                table: "Libro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdVenta",
                table: "Libro",
                column: "IdVenta");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Venta_IdVenta",
                table: "Libro",
                column: "IdVenta",
                principalTable: "Venta",
                principalColumn: "IdVenta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
