using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Problem.Query.GetById
{
    public class ProblemGetByIdQueryHandler : IRequestHandler<ProblemGetByIdQuery, ProblemGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;

        public ProblemGetByIdQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<ProblemGetByIdDto> Handle(ProblemGetByIdQuery request, CancellationToken cancellationToken)
        {
            var Problem = await _HDIContext.Problem.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Include(x => x.WarrantyType).FirstOrDefaultAsync(x => x.Id == request.ProblemId && !x.IsDeleted);

            if (Problem == null)
                return null;

            var ProblemDto = new ProblemGetByIdDto()
            {
                UpdatedUser = Problem.UpdatedUser == null ? null : Problem.UpdatedUser.NameSurname,
                CreatedDate = Problem.CreatedDate,
                CreatedUser = Problem.CreatedUser == null ? null : Problem.CreatedUser.NameSurname,
                Name = Problem.Name,
                Id = request.ProblemId,
                UpdatedDate = Problem.UpdatedDate,
                WarrantyType = Problem.WarrantyType.Name,
                WarrantyTypeId = Problem.WarrantyTypeId
            };

            return ProblemDto;
        }
    }
}