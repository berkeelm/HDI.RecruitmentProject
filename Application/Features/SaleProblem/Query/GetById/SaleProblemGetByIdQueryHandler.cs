using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleProblem.Query.GetById
{
    public class SaleProblemGetByIdQueryHandler : IRequestHandler<SaleProblemGetByIdQuery, SaleProblemGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;

        public SaleProblemGetByIdQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<SaleProblemGetByIdDto> Handle(SaleProblemGetByIdQuery request, CancellationToken cancellationToken)
        {
            var SaleProblem = await _HDIContext.SaleProblem.Include(x => x.CreatedUser)
                                      .Include(x => x.UpdatedUser)
                                      .Include(x => x.Problem)
                                      .ThenInclude(x => x.WarrantyType)
                                      .FirstOrDefaultAsync(x => x.Id == request.SaleProblemId && !x.IsDeleted);

            if (SaleProblem == null)
                return null;

            var SaleProblemDto = new SaleProblemGetByIdDto()
            {
                UpdatedUser = SaleProblem.UpdatedUser == null ? null : SaleProblem.UpdatedUser.NameSurname,
                CreatedDate = SaleProblem.CreatedDate,
                CreatedUser = SaleProblem.CreatedUser == null ? null : SaleProblem.CreatedUser.NameSurname,
                UpdatedDate = SaleProblem.UpdatedDate,
                Id = SaleProblem.Id,
                Price = SaleProblem.Price,
                Problem = SaleProblem.Problem.Name,
                ProblemId = SaleProblem.ProblemId,
                SaleId = SaleProblem.SaleId,
                WarrantyType = SaleProblem.Problem.WarrantyType.Name
            };

            return SaleProblemDto;
        }
    }
}