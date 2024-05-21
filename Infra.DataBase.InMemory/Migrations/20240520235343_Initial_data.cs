using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Initial_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "PedidoStatus",
               columns: new[] { "Nome" },
               values: new object[,]
               {
                    { "Pendente" },
                    { "Processando" },
                    { "Enviado" },
                    { "Entregue" },
                    { "Cancelado" },
                    { "Devolvido" }
               });

            migrationBuilder.InsertData(
                table: "PedidosPagamentos",
                columns: new[] { "Nome" },
                values: new object[,]
                {
                    { "Aguardando" },
                    { "Pago" },
                    { "Recusado" },
                    { "Error" }
                });

            migrationBuilder.InsertData(
                table: "ProdutoCategorias",
                columns: new[] { "Nome" },
                values: new object[,]
                {
                    { "Bebidas" },
                    { "Acompanhamento" },
                    { "Sobremesa" },
                    { "Outros" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
