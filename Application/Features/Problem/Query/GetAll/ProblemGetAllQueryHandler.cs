using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Problem.Query.GetAll
{
    public class ProblemGetAllQueryHandler : IRequestHandler<ProblemGetAllQuery, List<ProblemGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public ProblemGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<ProblemGetAllDto>> Handle(ProblemGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.Problem.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Include(x => x.WarrantyType).Where(x => !x.IsDeleted);

            if (request.SaleId.HasValue)
            {
                var activeWarranty = await _HDIContext.SaleWarranty.FirstOrDefaultAsync(x => x.SaleId == request.SaleId && DateTime.Now >= x.StartDate && DateTime.Now <= x.EndDate && !x.IsDeleted);

                if (activeWarranty != null)
                {
                    dbQuery = dbQuery.Where(x => x.WarrantyTypeId == activeWarranty.WarrantyTypeId);
                }
            }

            var Problems = await dbQuery.ToListAsync(cancellationToken);

            var ProblemsDto = Problems.Select(x => new ProblemGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                Name = x.Name,
                WarrantyType = x.WarrantyType.Name,
                WarrantyTypeId = x.WarrantyTypeId
            });

            return ProblemsDto.ToList();
        }
    }
}