using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Dashboard.Query.GetTopRepairCenters
{
    public class GetTopRepairCentersQueryHandler : IRequestHandler<GetTopRepairCentersQuery, List<GetTopRepairCentersDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTopRepairCentersQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetTopRepairCentersDto>> Handle(GetTopRepairCentersQuery request, CancellationToken cancellationToken)
        {
            var result = _HDIContext.SaleProblem.Include(x => x.CreatedUser)
                                                .Where(x => !x.IsDeleted && !x.CreatedUser.IsDeleted)
                                                .GroupBy(x => x.CreatedUser.NameSurname)
                                                .Select(x => new GetTopRepairCentersDto()
                                                {
                                                    Key = x.Key,
                                                    Value = x.Count()
                                                })
                                                .OrderByDescending(x => x.Value)
                                                .Take(10);

            return result.ToList();
        }
    }
}