using Application.Features.Dashboard.Query.GetMostCommonProblems;
using Application.Features.Dashboard.Query.GetMostProblematicProducts;
using Application.Features.Dashboard.Query.GetTopRepairCenters;
using Application.Features.Dashboard.Query.GetTopSellingDealers;
using Application.Features.Dashboard.Query.GetTopSellingProducts;

namespace WebUI.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<GetTopSellingDealersDto> TopSellingDealers { get; set; }
        public List<GetTopRepairCentersDto> TopRepairCenters { get; set; }
        public List<GetTopSellingProductsDto> TopSellingProducts { get; set; }
        public List<GetMostProblematicProductsDto> MostProblematicProducts { get; set; }
        public List<GetMostCommonProblemsDto> MostCommonProblems { get; set; }
    }
}
