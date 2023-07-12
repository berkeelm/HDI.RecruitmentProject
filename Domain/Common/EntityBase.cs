using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public abstract class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("CreatedUserId")]
        public virtual User CreatedUser { get; set; }
        [ForeignKey("UpdatedUserId")]
        public virtual User UpdatedUser { get; set; }
    }
}