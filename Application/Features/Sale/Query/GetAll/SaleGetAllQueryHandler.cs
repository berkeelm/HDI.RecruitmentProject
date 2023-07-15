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
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (Guid)_httpContextAccessor.HttpContext.Items["User"]);

            var dbQuery = _HDIContext.Sale.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Include(x => x.Product).Include(x => x.Customer).Include(x => x.RepairChangeCenterUser).Include(x => x.SaleWarranty).Where(x => !x.IsDeleted);

            if (!string.IsNullOrEmpty(request.ProductName))
            {
                dbQuery = dbQuery.Where(x => x.Product.Name.ToLower().Contains(request.ProductName.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.CustomerName))
            {
                dbQuery = dbQuery.Where(x => x.Customer.NameSurname.ToLower().Contains(request.CustomerName.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.RepairChangeCenterName))
            {
                dbQuery = dbQuery.Where(x => x.RepairChangeCenterUser.NameSurname.ToLower().Contains(request.RepairChangeCenterName.ToLower()));
            }

            if (request.CreatedDate.HasValue)
            {
                var startDate = request.CreatedDate.GetValueOrDefault();
                var endDate = request.CreatedDate.GetValueOrDefault().AddDays(1).AddSeconds(-1);
                dbQuery = dbQuery.Where(x => x.CreatedDate >= startDate && x.CreatedDate <= endDate);
            }

            if (!string.IsNullOrEmpty(request.CreatedUser))
            {
                dbQuery = dbQuery.Where(x => x.CreatedUser.NameSurname.ToLower().Contains(request.CreatedUser.ToLower()));
            }

            // Eğer bayi login oluyorsa sadece kendi satışlarını görür

            if (currentUser.UserType == Domain.Enums.UserType.DealerUser)
            {
                dbQuery = dbQuery.Where(x => x.CreatedUserId == currentUser.Id);
            }

            // Eğer teknik servis login oluyorsa sadece kendi satışlarını görür

            if (currentUser.UserType == Domain.Enums.UserType.RepairChangeCenterUser)
            {
                dbQuery = dbQuery.Where(x => x.RepairChangeCenterUserId == currentUser.Id);
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
                RepairChangeCenterUserId = x.RepairChangeCenterUserId,
                IsWarrantyActive = x.SaleWarranty.Any(x => DateTime.Now >= x.StartDate && DateTime.Now <= x.EndDate && !x.IsDeleted)
            });

            return SalesDto.ToList();
        }
    }
}