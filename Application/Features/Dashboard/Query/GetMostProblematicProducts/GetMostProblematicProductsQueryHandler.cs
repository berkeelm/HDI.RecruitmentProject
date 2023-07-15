using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Dashboard.Query.GetMostProblematicProducts
{
    public class GetMostProblematicProductsQueryHandler : IRequestHandler<GetMostProblematicProductsQuery, List<GetMostProblematicProductsDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetMostProblematicProductsQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetMostProblematicProductsDto>> Handle(GetMostProblematicProductsQuery request, CancellationToken cancellationToken)
        {
            var result = _HDIContext.SaleProblem.Include(x => x.Sale)
                                                .ThenInclude(x => x.Product)
                                                .Where(x => !x.IsDeleted && !x.Sale.IsDeleted && !x.Sale.Product.IsDeleted)
                                                .GroupBy(x => x.Sale.Product.Name)
                                                .Select(x => new GetMostProblematicProductsDto()
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