using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Dashboard.Query.GetTopSellingProducts
{
    public class GetTopSellingProductsQueryHandler : IRequestHandler<GetTopSellingProductsQuery, List<GetTopSellingProductsDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTopSellingProductsQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetTopSellingProductsDto>> Handle(GetTopSellingProductsQuery request, CancellationToken cancellationToken)
        {
            var result = _HDIContext.Sale.Include(x => x.Product)
                                         .Where(x => !x.IsDeleted && !x.Product.IsDeleted)
                                         .GroupBy(x => x.Product.Name)
                                         .Select(x => new GetTopSellingProductsDto()
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