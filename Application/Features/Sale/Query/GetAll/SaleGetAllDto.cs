namespace Application.Features.Sale.Query.GetAll
{
    public class SaleGetAllDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}