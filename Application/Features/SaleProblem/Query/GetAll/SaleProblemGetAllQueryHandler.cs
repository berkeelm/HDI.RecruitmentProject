using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleProblem.Query.GetAll
{
    public class SaleProblemGetAllQueryHandler : IRequestHandler<SaleProblemGetAllQuery, List<SaleProblemGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public SaleProblemGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<SaleProblemGetAllDto>> Handle(SaleProblemGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.SaleProblem.Include(x => x.CreatedUser)
                                                  .Include(x => x.UpdatedUser)
                                                  .Include(x => x.Problem)
                                                  .ThenInclude(x => x.WarrantyType)
                                                  .Where(x => !x.IsDeleted);

            if (request.SaleId.HasValue)
            {
                dbQuery = dbQuery.Where(x => x.SaleId == request.SaleId);
            }

            var SaleProblems = await dbQuery.ToListAsync(cancellationToken);

            var SaleProblemsDto = SaleProblems.Select(x => new SaleProblemGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                Price = x.Price,
                Problem = x.Problem.Name,
                ProblemId = x.ProblemId,
                SaleId = x.SaleId,
                WarrantyType = x.Problem.WarrantyType.Name
            });

            return SaleProblemsDto.ToList();
        }
    }
}