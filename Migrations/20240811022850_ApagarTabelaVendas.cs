using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestao.Migrations
{
    /// <inheritdoc />
    public partial class ApagarTabelaVendas : Migration
    {         
        
            /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "Vendas"
                    );
            }
       

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        migrationBuilder.CreateTable(
           name: "Vendas",
           columns: table => new
           {
               ProtocoloVenda = table.Column<int>(type: "int", nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
               VeiculoId = table.Column<int>(type: "int", nullable: false),
               VeiculoModelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
               Concessionaria = table.Column<string>(type: "nvarchar(100)", nullable: false),
               ClienteCPF = table.Column<string>(type: "char(14)", nullable: false),
               NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
               FoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
               DataVenda = table.Column<DateTime>(type: "datetime2", nullable: true),
               PrecoVenda = table.Column<float>(type: "real", nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Vendas", x => x.ProtocoloVenda);
               table.ForeignKey(
                   name: "FK_Vendas_Concessionarias_Concessionaria",
                   column: x => x.Concessionaria,
                   principalTable: "Concessionarias",
                   principalColumn: "Concessionaria",
                   onDelete: ReferentialAction.Cascade);
               table.ForeignKey(
                   name: "FK_Vendas_Veiculos_VeiculoId",
                   column: x => x.VeiculoId,
                   principalTable: "Veiculos",
                   principalColumn: "Id",
                   onDelete: ReferentialAction.Cascade);
           });

    }
}
}
