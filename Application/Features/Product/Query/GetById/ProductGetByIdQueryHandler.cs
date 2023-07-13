using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Query.GetById
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, ProductGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;

        public ProductGetByIdQueryHandler(IHDIContext HDIContext)
        {
            _HDIContext = HDIContext;
        }

        public async Task<ProductGetByIdDto> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            var Product = await _HDIContext.Product.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).FirstOrDefaultAsync(x => x.Id == request.ProductId && !x.IsDeleted);

            if (Product == null)
                return null;

            var ProductDto = new ProductGetByIdDto()
            {
                UpdatedUser = Product.UpdatedUser == null ? null : Product.UpdatedUser.NameSurname,
                CreatedDate = Product.CreatedDate,
                CreatedUser = Product.CreatedUser == null ? null : Product.CreatedUser.NameSurname,
                PhotoPath = Product.PhotoPath,
                Price = Product.Price,
                Description = Product.Description,
                Name = Product.Name,
                Id = request.ProductId,
                UpdatedDate = Product.UpdatedDate
            };

            return ProductDto;
        }
    }
}