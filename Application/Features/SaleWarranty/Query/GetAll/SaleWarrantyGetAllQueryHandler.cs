using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleWarranty.Query.GetAll
{
    public class SaleWarrantyGetAllQueryHandler : IRequestHandler<SaleWarrantyGetAllQuery, List<SaleWarrantyGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public SaleWarrantyGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<SaleWarrantyGetAllDto>> Handle(SaleWarrantyGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.SaleWarranty.Include(x => x.CreatedUser)
                                                  .Include(x => x.UpdatedUser)
                                                  .Include(x => x.Sale)
                                                  .ThenInclude(x => x.Product)
                                                  .Include(x => x.Sale)
                                                  .ThenInclude(x => x.Customer)
                                                  .Include(x => x.WarrantyType)
                                                  .Where(x => !x.IsDeleted);

            var SaleWarrantys = await dbQuery.ToListAsync(cancellationToken);

            var SaleWarrantysDto = SaleWarrantys.Select(x => new SaleWarrantyGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                CustomerName = x.Sale.Customer.NameSurname,
                PhotoPath = x.Sale.Product.PhotoPath,
                ProductId = x.Sale.ProductId,
                ProductName = x.Sale.Product.Name,
                SaleDate = x.Sale.CreatedDate,
                SaleId = x.Sale.Id,
                SalePrice = x.Sale.Price,
                WarrantyType = x.WarrantyType.Name,
                WarrantyTypeId = x.WarrantyTypeId
            });

            return SaleWarrantysDto.ToList();
        }
    }
}