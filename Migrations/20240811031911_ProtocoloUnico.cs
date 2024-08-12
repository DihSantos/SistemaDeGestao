using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestao.Migrations
{
    /// <inheritdoc />
    public partial class ProtocoloUnico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProtocoloVenda",
                table: "Vendas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ProtocoloVenda",
                table: "Vendas",
                column: "ProtocoloVenda",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vendas_ProtocoloVenda",
                table: "Vendas");

            migrationBuilder.AlterColumn<string>(
                name: "ProtocoloVenda",
                table: "Vendas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
