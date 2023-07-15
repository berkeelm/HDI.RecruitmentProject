using MediatR;

namespace Application.Features.Sale.Query.GetAll
{
    public class SaleGetAllQuery : IRequest<List<SaleGetAllDto>>
    {
        public string? ProductName { get; set; } = null;
        public string? CustomerName { get; set; } = null;
        public string? RepairChangeCenterName { get; set; } = null;
        public DateTime? CreatedDate { get; set; } = null;
        public string? CreatedUser { get; set; } = null;

        public SaleGetAllQuery(string? ProductName, string? CustomerName, string? RepairChangeCenterName, DateTime? CreatedDate, string? CreatedUser)
        {
            this.ProductName = ProductName;
            this.CustomerName = CustomerName;
            this.RepairChangeCenterName = RepairChangeCenterName;
            this.CreatedDate = CreatedDate;
            this.CreatedUser = CreatedUser;
        }

        public SaleGetAllQuery()
        {
        }
    }
}