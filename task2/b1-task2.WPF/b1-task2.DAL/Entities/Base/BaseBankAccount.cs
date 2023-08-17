using System.ComponentModel.DataAnnotations;

namespace b1_task2.DAL.Entities
{
    public  class BaseBankAccount : BaseEntity
    {
        public int BankAccountNumber { get; set; }
    }
}
