using System.ComponentModel.DataAnnotations;

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
    }
}