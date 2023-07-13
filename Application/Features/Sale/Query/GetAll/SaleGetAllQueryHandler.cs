using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sale.Query.GetAll
{
    public class SaleGetAllQueryHandler : IRequestHandler<SaleGetAllQuery, List<SaleGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleGetAllQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<SaleGetAllDto>> Handle(SaleGetAllQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (int)_httpContextAccessor.HttpContext.Items["User"]);

            var dbQuery = _HDIContext.Sale.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Include(x => x.Product).Include(x => x.Customer).Include(x => x.RepairChangeCenterUser).Where(x => !x.IsDeleted);

            // Eğer bayi login oluyorsa sadece kendi satışlarını görür

            if (currentUser.UserType == Domain.Enums.UserType.DealerUser)
            {
                dbQuery = dbQuery.Where(x => x.CreatedUserId == currentUser.Id);
            }

            var Sales = await dbQuery.ToListAsync(cancellationToken);

            var SalesDto = Sales.Select(x => new SaleGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                CustomerId = x.CustomerId,
                Customer = x.Customer.NameSurname,
                Price = x.Price,
                Product = x.Product.Name,
                ProductId = x.ProductId,
                PhotoPath = x.Product.PhotoPath,
                RepairChangeCenterUser = x.RepairChangeCenterUser.NameSurname,
                RepairChangeCenterUserId = x.RepairChangeCenterUserId
            });

            return SalesDto.ToList();
        }
    }
}