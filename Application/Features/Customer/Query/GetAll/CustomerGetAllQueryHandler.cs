using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customer.Query.GetAll
{
    public class CustomerGetAllQueryHandler : IRequestHandler<CustomerGetAllQuery, List<CustomerGetAllDto>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerGetAllQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CustomerGetAllDto>> Handle(CustomerGetAllQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (int)_httpContextAccessor.HttpContext.Items["User"]);

            var dbQuery = _HDIContext.Customer.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => !x.IsDeleted);

            // Eğer bayi login oluyorsa sadece kendi müşterilerini görür

            if (currentUser.UserType == Domain.Enums.UserType.DealerUser)
            {
                dbQuery = dbQuery.Where(x => x.CreatedUserId == currentUser.Id);
            }

            var Customers = await dbQuery.ToListAsync(cancellationToken);

            var CustomersDto = Customers.Select(x => new CustomerGetAllDto()
            {
                UpdatedUser = x.UpdatedUser == null ? null : x.UpdatedUser.NameSurname,
                CreatedDate = x.CreatedDate,
                CreatedUser = x.CreatedUser == null ? null : x.CreatedUser.NameSurname,
                UpdatedDate = x.UpdatedDate,
                Id = x.Id,
                Address = x.Address,
                Mail = x.Mail,
                NameSurname = x.NameSurname,
                Phone = x.Phone
            });

            return CustomersDto.ToList();
        }
    }
}