using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestao.Migrations
{
    /// <inheritdoc />
    public partial class AjustesConexão : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_Concessionaria",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_Fabricante",
                table: "Veiculos");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteCPF",
                table: "Vendas",
                type: "char(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(14)");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteCPF",
                table: "Vendas",
                column: "ClienteCPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Concessionaria",
                table: "Vendas",
                column: "Concessionaria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas",
                column: "VeiculoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Fabricante",
                table: "Veiculos",
                column: "Fabricante",
                unique: true,
                filter: "[Fabricante] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vendas_ClienteCPF",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_Concessionaria",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Veiculos_Fabricante",
                table: "Veiculos");

            migrationBuilder.AlterColumn<string>(
                name: "ClienteCPF",
                table: "Vendas",
                type: "char(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Concessionaria",
                table: "Vendas",
                column: "Concessionaria");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Fabricante",
                table: "Veiculos",
                column: "Fabricante");
        }
    }
}
