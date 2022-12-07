using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SONMARKET.Migrations
{
    public partial class ModificandoVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Estoques",
                newName: "ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_ProdutoId",
                table: "Estoques",
                newName: "IX_Estoques_ProdutoID");

            migrationBuilder.AddColumn<float>(
                name: "Quantidade",
                table: "Saidas",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "vendaId",
                table: "Saidas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Saidas_vendaId",
                table: "Saidas",
                column: "vendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoID",
                table: "Estoques",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Saidas_Vendas_vendaId",
                table: "Saidas",
                column: "vendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoID",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Saidas_Vendas_vendaId",
                table: "Saidas");

            migrationBuilder.DropIndex(
                name: "IX_Saidas_vendaId",
                table: "Saidas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Saidas");

            migrationBuilder.DropColumn(
                name: "vendaId",
                table: "Saidas");

            migrationBuilder.RenameColumn(
                name: "ProdutoID",
                table: "Estoques",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoques_ProdutoID",
                table: "Estoques",
                newName: "IX_Estoques_ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
