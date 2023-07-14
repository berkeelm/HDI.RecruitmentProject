using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleWarranty.Query.GetById
{
    public class SaleWarrantyGetByIdQueryHandler : IRequestHandler<SaleWarrantyGetByIdQuery, SaleWarrantyGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;

        public SaleWarrantyGetByIdQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<SaleWarrantyGetByIdDto> Handle(SaleWarrantyGetByIdQuery request, CancellationToken cancellationToken)
        {
            var SaleWarranty = await _HDIContext.SaleWarranty.Include(x => x.CreatedUser)
                                                       .Include(x => x.UpdatedUser)
                                                       .Include(x => x.Sale)
                                                       .ThenInclude(x => x.Product)
                                                       .Include(x => x.Sale)
                                                       .ThenInclude(x => x.Customer)
                                                       .Include(x => x.WarrantyType)
                                                       .FirstOrDefaultAsync(x => x.Id == request.SaleWarrantyId && !x.IsDeleted);

            if (SaleWarranty == null)
                return null;

            var SaleWarrantyDto = new SaleWarrantyGetByIdDto()
            {
                UpdatedUser = SaleWarranty.UpdatedUser == null ? null : SaleWarranty.UpdatedUser.NameSurname,
                CreatedDate = SaleWarranty.CreatedDate,
                CreatedUser = SaleWarranty.CreatedUser == null ? null : SaleWarranty.CreatedUser.NameSurname,
                UpdatedDate = SaleWarranty.UpdatedDate,
                Id = SaleWarranty.Id,
                EndDate = SaleWarranty.EndDate,
                StartDate = SaleWarranty.StartDate,
                CustomerName = SaleWarranty.Sale.Customer.NameSurname,
                PhotoPath = SaleWarranty.Sale.Product.PhotoPath,
                ProductId = SaleWarranty.Sale.ProductId,
                ProductName = SaleWarranty.Sale.Product.Name,
                SaleDate = SaleWarranty.Sale.CreatedDate,
                SaleId = SaleWarranty.Sale.Id,
                SalePrice = SaleWarranty.Sale.Price,
                WarrantyType = SaleWarranty.WarrantyType.Name,
                WarrantyTypeId = SaleWarranty.WarrantyTypeId
            };

            return SaleWarrantyDto;
        }
    }
}