using Application.Features.Sale.Query.GetById;
using Application.Features.SaleProblem.Query.GetAll;
using Application.Features.SaleWarranty.Query.GetAll;

namespace WebUI.Models.ViewModels
{
    public class SaleHistoryViewModel
    {
        public SaleGetByIdDto Sale { get; set; }
        public List<SaleWarrantyGetAllDto> SaleWarranties { get; set; }
        public List<SaleProblemGetAllDto> SaleProblems { get; set; }
    }
}
