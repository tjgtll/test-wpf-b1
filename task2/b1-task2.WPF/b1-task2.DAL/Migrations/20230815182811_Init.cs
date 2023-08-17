using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace b1_task2.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceSheets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountMovements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpeningBalanceActive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpeningBalancePassive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnoverCredit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnoverDebit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    СlosingBalanceActive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    СlosingBalancePassive = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceSheetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BankAccountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccountMovements_BalanceSheets_BalanceSheetId",
                        column: x => x.BalanceSheetId,
                        principalTable: "BalanceSheets",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ChartOfAccounts",
                columns: new[] { "Id", "BankAccountNumber", "Name", "TypeAccount" },
                values: new object[,]
                {
                    { new Guid("1697acae-aa75-47c1-aa07-10b9f38548e1"), 4, "Ценные бумаги", "-" },
                    { new Guid("3654bc95-64ee-4a2f-95a3-c01b972a5f9d"), 1, "Денежные средства, драгоценные металлы и межбанковские операции", "-" },
                    { new Guid("7f6cf8d7-383d-4950-b042-39474faedc4e"), 2, "Кредитные и иные активные операции с клиентами", "-" },
                    { new Guid("9f3ef987-e6ea-4ac5-818d-ab7f09453845"), 7, "Собственный капитал банка", "-" },
                    { new Guid("bdd1223a-a93c-49a7-b9e5-9b74afc87286"), 5, "Долгосрочные финансовые вложения в уставные фонды юридических лиц, основные средства и прочее имущество", "-" },
                    { new Guid("d1e211f1-0bc4-4220-bf82-957dd9604a66"), 9, "Расходы банка", "-" },
                    { new Guid("de4f02f0-0d7d-49b0-9a88-0c41016e9587"), 8, "Доходы банка", "-" },
                    { new Guid("ec633c48-7b76-4864-b5ce-a30308c0f866"), 6, "Прочие активы и прочие пассивы", "-" },
                    { new Guid("f8d2ade1-fb8d-434a-8a52-b3b1d9a3f9ce"), 3, "Счета по операциям клиентов", "-" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountMovements_BalanceSheetId",
                table: "BankAccountMovements",
                column: "BalanceSheetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccountMovements");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "BalanceSheets");
        }
    }
}
