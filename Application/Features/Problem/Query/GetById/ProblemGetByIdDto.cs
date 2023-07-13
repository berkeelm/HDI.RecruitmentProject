using Domain.Enums;

namespace Application.Features.Problem.Query.GetById
{
    public class ProblemGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int WarrantyTypeId { get; set; }
        public string WarrantyType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}