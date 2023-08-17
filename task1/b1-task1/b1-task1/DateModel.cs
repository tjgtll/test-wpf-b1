using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace b1_task1
{
    [Keyless]
    [Table("random_date")]
    public class DateModel
    {
        public DateTime DateTime { get; set; }
        public string Latin { get; set; }
        public string Russian { get; set; }
        public int RandomInt { get; set; }
        public double RandomDouble { get; set; }
    }


}
