using Application.Features.Sale.Query.GetAll;

namespace WebUI.Models.ViewModels
{
    public class SaleListViewModel
    {
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public List<SaleGetAllDto> SaleList { get; set; }
        public string RepairChangeCenterName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedUser { get; set; }
    }
}
