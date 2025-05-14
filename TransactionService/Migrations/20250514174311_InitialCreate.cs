using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransactionService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    TypeTransactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "TypeTransaction",
                columns: table => new
                {
                    TypeTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeTransactionName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTransaction", x => x.TypeTransactionId);
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionId", "AccountId", "Amount", "TransactionDate", "TypeTransactionId" },
                values: new object[,]
                {
                    { 1, 1, 8798.13m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 8798.13m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "TypeTransaction",
                columns: new[] { "TypeTransactionId", "TypeTransactionName" },
                values: new object[,]
                {
                    { 1, "Depósito" },
                    { 2, "Saque" },
                    { 3, "Saldo" },
                    { 4, "Pix" },
                    { 5, "Transferência" },
                    { 6, "Pagamento" },
                    { 7, "Recarga de Celular" },
                    { 8, "Comprovantes" },
                    { 9, "Extrato Simples" },
                    { 10, "Extrato por Período" },
                    { 11, "Bloqueio de Conta" },
                    { 12, "Desbloqueio de Conta" },
                    { 13, "Alteração de Limite Diário" },
                    { 14, "Cancelamento de Conta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "TypeTransaction");
        }
    }
}
