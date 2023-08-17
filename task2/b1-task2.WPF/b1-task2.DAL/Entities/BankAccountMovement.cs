using System.ComponentModel.DataAnnotations.Schema;

namespace b1_task2.DAL.Entities
{
    public class BankAccountMovement : BaseBankAccount
    {
        public decimal OpeningBalanceActive { get; set; }

        public decimal OpeningBalancePassive { get; set; }

        public decimal TurnoverCredit { get; set; }

        public decimal TurnoverDebit { get; set; }

        public decimal СlosingBalanceActive { get; set; }

        public decimal СlosingBalancePassive { get; set; }

        public Guid BalanceSheetId { get;set; }
    }
}
