using Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customer.Query.GetById
{
    public class CustomerGetByIdQueryHandler : IRequestHandler<CustomerGetByIdQuery, CustomerGetByIdDto>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerGetByIdQueryHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CustomerGetByIdDto> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (int)_httpContextAccessor.HttpContext.Items["User"]);

            var dbQuery = _HDIContext.Customer.Include(x => x.CreatedUser).Include(x => x.UpdatedUser).Where(x => x.Id == request.CustomerId && !x.IsDeleted);

            // Eğer bayi login oluyorsa sadece kendi müşterilerini görür

            if (currentUser.UserType == Domain.Enums.UserType.DealerUser)
            {
                dbQuery = dbQuery.Where(x => x.CreatedUserId == currentUser.Id);
            }

            var Customer = await dbQuery.FirstOrDefaultAsync(cancellationToken);

            if (Customer == null)
                return null;

            var CustomerDto = new CustomerGetByIdDto()
            {
                UpdatedUser = Customer.UpdatedUser == null ? null : Customer.UpdatedUser.NameSurname,
                CreatedDate = Customer.CreatedDate,
                CreatedUser = Customer.CreatedUser == null ? null : Customer.CreatedUser.NameSurname,
                Id = request.CustomerId,
                UpdatedDate = Customer.UpdatedDate,
                Phone = Customer.Phone,
                NameSurname = Customer.NameSurname,
                Mail = Customer.Mail,
                Address = Customer.Address
            };

            return CustomerDto;
        }
    }
}