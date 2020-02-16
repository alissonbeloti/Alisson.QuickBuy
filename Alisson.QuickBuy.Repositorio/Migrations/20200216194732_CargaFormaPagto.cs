using Microsoft.EntityFrameworkCore.Migrations;

namespace Alisson.QuickBuy.Repositorio.Migrations
{
    public partial class CargaFormaPagto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "FormaPagamentos",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100) CHARACTER SET utf8mb4",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "FormaPagamentos",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 1, "Forma de pagamento Boleto.", "Boleto" });

            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 2, "Forma de pagamento Cartão de Crédito.", "Cartão de Credito" });

            migrationBuilder.InsertData(
                table: "FormaPagamentos",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 3, "Forma de pagamento Depósito.", "Depósito" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FormaPagamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FormaPagamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FormaPagamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "FormaPagamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "FormaPagamentos",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
