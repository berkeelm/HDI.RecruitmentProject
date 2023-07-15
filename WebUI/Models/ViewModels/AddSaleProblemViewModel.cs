using Application.Features.Problem.Query.GetAll;
using Application.Features.Sale.Query.GetById;

namespace WebUI.Models.ViewModels
{
    public class AddSaleProblemViewModel
    {
        public SaleGetByIdDto Sale { get; set; }
        public List<ProblemGetAllDto> Problems { get; set; }
    }
}
