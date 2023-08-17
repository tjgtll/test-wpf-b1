using b1_task2.DAL.Entities;
using b1_task2.DAL.Repositories;
using IronXL;
using System.Text.RegularExpressions;

namespace b1_task2.BLL.Services
{
    public class ExcelFileManagerService : IExcelFileManagerService
    {
        private readonly IRepository<ChartOfAccount> _chartOfAccountRepository;
        private readonly IRepository<BalanceSheet> _balanceSheet;
        private readonly IRepository<BankAccountMovement> _bankAccountMovement;
        private const string pattern = @"\d{2}\.\d{2}\.\d{4}";
        private const string classMessage = "ПО КЛАССУ";

        public ExcelFileManagerService(
            IRepository<ChartOfAccount> chartOfAccountRepository, 
            IRepository<BalanceSheet> balanceSheet,
            IRepository<BankAccountMovement> bankAccountMovement)
        {
            _chartOfAccountRepository = chartOfAccountRepository;
            _balanceSheet = balanceSheet;
            _bankAccountMovement = bankAccountMovement;
        }
        public string ImportFile(Stream fileStream,string filePath,string fileName)
        {
            try
            {
                WorkBook workbook = WorkBook.Load(fileStream);
                WorkSheet sheet = workbook.WorkSheets[0];

                var balanceSheet = GetBalanceSheet(ref sheet, ref filePath,ref fileName);
               

                for (int i = 9; i < sheet.RowCount - 1; i++)
                {
                   
                    var range = sheet[$"A{i}:G{i}"].ToList();
                    int bankAccountNumber = 0;
                    if (!Int32.TryParse(range[0].StringValue, out var result))
                    {
                        if (range[0].StringValue == classMessage)
                        { 
                            bankAccountNumber = Convert.ToInt32(sheet[$"A{i - 1}"].StringValue[0..1]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        bankAccountNumber = result;
                    }

                    var bankAccountMovement = new BankAccountMovement()
                    {
                        BankAccountNumber = bankAccountNumber,
                        OpeningBalanceActive = (decimal)range[1].DecimalValue,
                        OpeningBalancePassive = (decimal)range[2].DecimalValue,
                        TurnoverCredit = (decimal)range[3].DecimalValue,
                        TurnoverDebit = (decimal)range[4].DecimalValue,
                        СlosingBalanceActive = (decimal)range[5].DecimalValue,
                        СlosingBalancePassive = (decimal)range[6].DecimalValue,
                    };
                    balanceSheet.BankAccountMovements.Add(bankAccountMovement);
                }
                workbook.Close();
                _balanceSheet.Add(balanceSheet);
                return balanceSheet.Id.ToString();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private BalanceSheet GetBalanceSheet(ref WorkSheet sheet, ref string filePath, ref string fileName)
        {
            MatchCollection matches = Regex.Matches(sheet["A3"].StringValue, pattern);
            if (matches.Count != 2)
            {
                return null;
            }

            DateTime.TryParseExact(matches[0].Value, "dd.MM.yyyy",
                null, System.Globalization.DateTimeStyles.None, out var dateTimeStart);
            DateTime.TryParseExact(matches[1].Value, "dd.MM.yyyy",
                null, System.Globalization.DateTimeStyles.None, out var dateTimeEnd);
            var id = Guid.NewGuid();
            var balanceSheet = new BalanceSheet()
            {
                Id = id,
                BankName = sheet["A1"].StringValue,
                StartDateTime = dateTimeStart,
                EndDateTime = dateTimeEnd,
                FilePath = $"{filePath}\\{id}.xls",
                FileName = fileName
            };
            balanceSheet.BankAccountMovements = new List<BankAccountMovement>();
            return balanceSheet;
        }
    }
}
