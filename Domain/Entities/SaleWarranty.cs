using Domain.Common;

namespace Domain.Entities
{
    public class SaleWarranty : EntityBase
    {
        public Guid SaleId { get; set; }
        public Guid WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual WarrantyType WarrantyType { get; set; }
    }
}