using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sale.Query.GetById
{
    public class SaleGetByIdQueryHandler : IRequestHandler<SaleGetByIdQuery, SaleGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleGetByIdQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<SaleGetByIdDto> Handle(SaleGetByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (int)_httpContextAccessor.HttpContext.Items["User"]);

            var dbQuery = _HDIContext.Sale.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => x.Id == request.SaleId && !x.IsDeleted);

            // Eğer bayi login oluyorsa sadece kendi satışlarını görür

            if (currentUser.UserType == Domain.Enums.UserType.DealerUser)
            {
                dbQuery = dbQuery.Where(x => x.CreatedUserId == currentUser.Id);
            }

            var Sale = await dbQuery.FirstOrDefaultAsync(cancellationToken);

            if (Sale == null)
                return null;

            var SaleDto = new SaleGetByIdDto()
            {
                UpdatedUser = Sale.UpdatedUser == null ? null : Sale.UpdatedUser.NameSurname,
                CreatedDate = Sale.CreatedDate,
                CreatedUser = Sale.CreatedUser == null ? null : Sale.CreatedUser.NameSurname,
                UpdatedDate = Sale.UpdatedDate,
                Id = Sale.Id,
                CustomerId = Sale.CustomerId,
                Customer = Sale.Customer.NameSurname,
                Price = Sale.Price,
                Product = Sale.Product.Name,
                ProductId = Sale.ProductId,
                PhotoPath = Sale.Product.PhotoPath
            };

            return SaleDto;
        }
    }
}