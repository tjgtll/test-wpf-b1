using System.ComponentModel.DataAnnotations;

namespace b1_task2.DAL.Entities
{
    public class BalanceSheet : BaseEntity
    {   
        public string BankName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        //directory/xsl
        public string FileName { get; set; }

        public string FilePath { get; set; }
        public ICollection<BankAccountMovement> BankAccountMovements { get; set; }
    }
}
