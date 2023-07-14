using Application.Features.Sale.Query.GetById;
using Application.Features.WarrantyType.Query.GetAll;

namespace WebUI.Models.ViewModels
{
    public class AddSaleWarrantyViewModel
    {
        public SaleGetByIdDto Sale { get; set; }
        public List<WarrantyTypeGetAllDto> WarrantyTypes { get; set; }
    }
}
