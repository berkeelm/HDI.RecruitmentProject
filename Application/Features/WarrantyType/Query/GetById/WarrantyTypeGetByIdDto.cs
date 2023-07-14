using Domain.Enums;

namespace Application.Features.WarrantyType.Query.GetById
{
    public class WarrantyTypeGetByIdDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}