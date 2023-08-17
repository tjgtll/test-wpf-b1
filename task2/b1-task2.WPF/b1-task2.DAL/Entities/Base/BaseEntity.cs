using System.ComponentModel.DataAnnotations;

namespace b1_task2.DAL.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
