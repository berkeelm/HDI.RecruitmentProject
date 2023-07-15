using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Dashboard.Query.GetMostCommonProblems
{
    public class GetMostCommonProblemsQueryHandler : IRequestHandler<GetMostCommonProblemsQuery, List<GetMostCommonProblemsDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetMostCommonProblemsQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<GetMostCommonProblemsDto>> Handle(GetMostCommonProblemsQuery request, CancellationToken cancellationToken)
        {
            var result = _HDIContext.SaleProblem.Include(x => x.Problem)
                                                .Where(x => !x.IsDeleted && !x.Problem.IsDeleted)
                                                .GroupBy(x => x.Problem.Name)
                                                .Select(x => new GetMostCommonProblemsDto()
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