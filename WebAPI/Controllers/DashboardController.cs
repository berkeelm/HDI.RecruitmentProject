using Application.Features.Dashboard.Query.GetMostCommonProblems;
using Application.Features.Dashboard.Query.GetMostProblematicProducts;
using Application.Features.Dashboard.Query.GetTopRepairCenters;
using Application.Features.Dashboard.Query.GetTopSellingDealers;
using Application.Features.Dashboard.Query.GetTopSellingProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    public class DashboardController : ApiControllerBase
    {
        [HttpPost("GetTopSellingDealers")]
        public async Task<IActionResult> GetTopSellingDealersAsync(GetTopSellingDealersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetTopRepairCenters")]
        public async Task<IActionResult> GetTopRepairCentersAsync(GetTopRepairCentersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetTopSellingProducts")]
        public async Task<IActionResult> GetTopSellingProductsAsync(GetTopSellingProductsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetMostProblematicProducts")]
        public async Task<IActionResult> GetMostProblematicProductsAsync(GetMostProblematicProductsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost("GetMostCommonProblems")]
        public async Task<IActionResult> GetMostCommonProblemsAsync(GetMostCommonProblemsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}