using Domain.Common;

namespace Domain.Entities
{
    public class Problem : EntityBase
    {
        public int WarrantyTypeId { get; set; }
        public virtual WarrantyType WarrantyType { get; set; }
        public string Name { get; set; }
    }
}