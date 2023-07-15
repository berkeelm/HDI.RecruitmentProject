using Application.Features.Dashboard.Query.GetMostCommonProblems;
using Application.Features.Dashboard.Query.GetMostProblematicProducts;
using Application.Features.Dashboard.Query.GetTopRepairCenters;
using Application.Features.Dashboard.Query.GetTopSellingDealers;
using Application.Features.Dashboard.Query.GetTopSellingProducts;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using WebUI.Filters;
using WebUI.Interfaces;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    [AuthorizationFilter(new UserType[] { UserType.FirmUser })]
    public class DashboardController : BaseController
    {
        public DashboardController(IRequestHelper requestHelper, IWebHostEnvironment env) : base(requestHelper, env)
        {
        }

        public IActionResult Index()
        {
            var TopSellingDealers = _requestHelper.SendRequest<List<GetTopSellingDealersDto>>("/Dashboard/GetTopSellingDealers", new GetTopSellingDealersQuery());
            var TopRepairCenters = _requestHelper.SendRequest<List<GetTopRepairCentersDto>>("/Dashboard/GetTopRepairCenters", new GetTopRepairCentersQuery());
            var TopSellingProducts = _requestHelper.SendRequest<List<GetTopSellingProductsDto>>("/Dashboard/GetTopSellingProducts", new GetTopSellingProductsQuery());
            var MostProblematicProducts = _requestHelper.SendRequest<List<GetMostProblematicProductsDto>>("/Dashboard/GetMostProblematicProducts", new GetMostProblematicProductsQuery());
            var MostCommonProblems = _requestHelper.SendRequest<List<GetMostCommonProblemsDto>>("/Dashboard/GetMostCommonProblems", new GetMostCommonProblemsQuery());

            var viewModel = new DashboardViewModel()
            {
                TopSellingDealers = TopSellingDealers,
                TopRepairCenters = TopRepairCenters,
                TopSellingProducts = TopSellingProducts,
                MostProblematicProducts = MostProblematicProducts,
                MostCommonProblems = MostCommonProblems
            };

            return View(viewModel);
        }
    }
}
