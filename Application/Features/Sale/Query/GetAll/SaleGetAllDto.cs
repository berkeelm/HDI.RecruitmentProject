namespace Application.Features.Sale.Query.GetAll
{
    public class SaleGetAllDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Product { get; set; }
        public Guid CustomerId { get; set; }
        public string Customer { get; set; }
        public decimal Price { get; set; }
        public Guid RepairChangeCenterUserId { get; set; }
        public string RepairChangeCenterUser { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
        public bool IsWarrantyActive { get; set; }
    }
}