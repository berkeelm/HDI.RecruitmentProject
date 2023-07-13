using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WarrantyType.Query.GetAll
{
    public class WarrantyTypeGetAllQueryHandler : IRequestHandler<WarrantyTypeGetAllQuery, List<WarrantyTypeGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public WarrantyTypeGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<WarrantyTypeGetAllDto>> Handle(WarrantyTypeGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.WarrantyType.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => !x.IsDeleted);

            var WarrantyTypes = await dbQuery.ToListAsync(cancellationToken);

            var WarrantyTypesDto = WarrantyTypes.Select(x => new WarrantyTypeGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                Name = x.Name
            });

            return WarrantyTypesDto.ToList();
        }
    }
}