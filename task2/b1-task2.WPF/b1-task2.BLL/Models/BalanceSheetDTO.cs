using System.ComponentModel.DataAnnotations;

namespace b1_task2.BLL.Models
{
    public class BalanceSheetDTO : BaseEntityDTO
    {
        public string Id { get; set; }
        public string BankName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        //directory/xsl
        public string FileName { get; set; }

        public string FilePath { get; set; }
        public List<BankAccountMovementDTO> AccountMovement { get; set;}
    }
}
