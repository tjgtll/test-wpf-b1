namespace b1_task2.BLL.Models
{
    public class BankAccountMovementDTO : BaseEntityDTO
    {
        public int BankAccountNumber { get; set; }
        public decimal OpeningBalanceActive { get; set; }

        public decimal OpeningBalancePassive { get; set; }

        public decimal TurnoverCredit { get; set; }

        public decimal TurnoverDebit { get; set; }

        public decimal СlosingBalanceActive { get; set; }

        public decimal СlosingBalancePassive { get; set; }

    }
}
