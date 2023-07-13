using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WarrantyType.Query.GetById
{
    public class WarrantyTypeGetByIdQueryHandler : IRequestHandler<WarrantyTypeGetByIdQuery, WarrantyTypeGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;

        public WarrantyTypeGetByIdQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<WarrantyTypeGetByIdDto> Handle(WarrantyTypeGetByIdQuery request, CancellationToken cancellationToken)
        {
            var WarrantyType = await _HDIContext.WarrantyType.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).FirstOrDefaultAsync(x => x.Id == request.WarrantyTypeId && !x.IsDeleted);

            if (WarrantyType == null)
                return null;

            var WarrantyTypeDto = new WarrantyTypeGetByIdDto()
            {
                UpdatedUser = WarrantyType.UpdatedUser == null ? null : WarrantyType.UpdatedUser.NameSurname,
                CreatedDate = WarrantyType.CreatedDate,
                CreatedUser = WarrantyType.CreatedUser == null ? null : WarrantyType.CreatedUser.NameSurname,
                Name = WarrantyType.Name,
                Id = request.WarrantyTypeId,
                UpdatedDate = WarrantyType.UpdatedDate
            };

            return WarrantyTypeDto;
        }
    }
}