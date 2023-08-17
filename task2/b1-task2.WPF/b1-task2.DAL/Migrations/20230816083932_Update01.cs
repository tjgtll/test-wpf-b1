using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace b1_task2.DAL.Migrations
{
    public partial class Update01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("1697acae-aa75-47c1-aa07-10b9f38548e1"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("3654bc95-64ee-4a2f-95a3-c01b972a5f9d"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("7f6cf8d7-383d-4950-b042-39474faedc4e"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("9f3ef987-e6ea-4ac5-818d-ab7f09453845"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("bdd1223a-a93c-49a7-b9e5-9b74afc87286"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("d1e211f1-0bc4-4220-bf82-957dd9604a66"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("de4f02f0-0d7d-49b0-9a88-0c41016e9587"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("ec633c48-7b76-4864-b5ce-a30308c0f866"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("f8d2ade1-fb8d-434a-8a52-b3b1d9a3f9ce"));

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "BalanceSheets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "ChartOfAccounts",
                columns: new[] { "Id", "BankAccountNumber", "Name", "TypeAccount" },
                values: new object[,]
                {
                    { new Guid("19b96b44-af3c-49f3-9426-66e4bbd26608"), 9, "Расходы банка", "-" },
                    { new Guid("1d8eff1a-d950-4ea1-864d-04f08b7b8505"), 6, "Прочие активы и прочие пассивы", "-" },
                    { new Guid("2602ea60-3998-4fd1-b5f1-b65c8ffd5bfb"), 1, "Денежные средства, драгоценные металлы и межбанковские операции", "-" },
                    { new Guid("487f86bd-3b8c-4ce9-b701-50a11f9b9d52"), 3, "Счета по операциям клиентов", "-" },
                    { new Guid("4b1aff57-ec30-4fb3-8b28-c5cb30229a51"), 8, "Доходы банка", "-" },
                    { new Guid("8804bb19-4877-426d-bf14-b570b8f9e1bb"), 5, "Долгосрочные финансовые вложения в уставные фонды юридических лиц, основные средства и прочее имущество", "-" },
                    { new Guid("8c8dab8d-0109-4b58-bbb9-7c3c21cd6c37"), 2, "Кредитные и иные активные операции с клиентами", "-" },
                    { new Guid("ab1f9624-b264-4d42-a52e-8439d25f23ef"), 7, "Собственный капитал банка", "-" },
                    { new Guid("ef30fddc-531e-4551-b0ed-04fcdb066e12"), 4, "Ценные бумаги", "-" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("19b96b44-af3c-49f3-9426-66e4bbd26608"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("1d8eff1a-d950-4ea1-864d-04f08b7b8505"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("2602ea60-3998-4fd1-b5f1-b65c8ffd5bfb"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("487f86bd-3b8c-4ce9-b701-50a11f9b9d52"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("4b1aff57-ec30-4fb3-8b28-c5cb30229a51"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("8804bb19-4877-426d-bf14-b570b8f9e1bb"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("8c8dab8d-0109-4b58-bbb9-7c3c21cd6c37"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("ab1f9624-b264-4d42-a52e-8439d25f23ef"));

            migrationBuilder.DeleteData(
                table: "ChartOfAccounts",
                keyColumn: "Id",
                keyValue: new Guid("ef30fddc-531e-4551-b0ed-04fcdb066e12"));

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "BalanceSheets");

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
        }
    }
}
