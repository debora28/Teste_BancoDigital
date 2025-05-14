using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Agency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DailyLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountNumber", "AccountType", "Agency", "ClientId", "DailyLimit", "DateClosed", "DateOpened", "StatusId" },
                values: new object[,]
                {
                    { 1, "7460", "Corrente", "7460", 1, 2000m, new DateTime(2025, 5, 14, 14, 42, 11, 569, DateTimeKind.Local).AddTicks(435), new DateTime(2025, 5, 14, 14, 42, 11, 569, DateTimeKind.Local).AddTicks(421), 1 },
                    { 2, "7461", "Poupança", "7460", 2, 5000m, new DateTime(2025, 5, 14, 14, 42, 11, 569, DateTimeKind.Local).AddTicks(441), new DateTime(2025, 5, 14, 14, 42, 11, 569, DateTimeKind.Local).AddTicks(440), 2 },
                    { 3, "7462", "Corrente", "7460", 1, 2000m, new DateTime(2025, 5, 14, 14, 42, 11, 569, DateTimeKind.Local).AddTicks(443), new DateTime(2025, 5, 14, 14, 42, 11, 569, DateTimeKind.Local).AddTicks(443), 1 }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Ativo" },
                    { 2, "Bloqueado" },
                    { 3, "Desbloqueado" },
                    { 4, "Fechado" },
                    { 5, "Cancelado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
