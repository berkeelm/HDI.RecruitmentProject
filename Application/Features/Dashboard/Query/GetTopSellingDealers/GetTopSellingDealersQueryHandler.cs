using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Dashboard.Query.GetTopSellingDealers
{
    public class GetTopSellingDealersQueryHandler : IRequestHandler<GetTopSellingDealersQuery, List<GetTopSellingDealersDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTopSellingDealersQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetTopSellingDealersDto>> Handle(GetTopSellingDealersQuery request, CancellationToken cancellationToken)
        {
            var result = _HDIContext.Sale.Include(x => x.CreatedUser)
                                         .Where(x => !x.IsDeleted && !x.CreatedUser.IsDeleted)
                                         .GroupBy(x => x.CreatedUser.NameSurname)
                                         .Select(x => new GetTopSellingDealersDto()
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