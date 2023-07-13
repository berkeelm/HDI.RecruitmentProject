using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Query.GetAll
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, List<ProductGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;

        public ProductGetAllQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<List<ProductGetAllDto>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var dbQuery = _HDIContext.Product.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => !x.IsDeleted);

            var Products = await dbQuery.ToListAsync(cancellationToken);

            var ProductsDto = Products.Select(x => new ProductGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                PhotoPath = x.PhotoPath
            });

            return ProductsDto.ToList();
        }
    }
}