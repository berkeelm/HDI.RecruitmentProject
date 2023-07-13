using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customer.Command.Delete
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public CustomerDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var Customer = await _HDIContext.Customer.FirstOrDefaultAsync(x => x.Id == request.CustomerId && !x.IsDeleted);

            if (Customer == null)
                return new Response<bool>($"Müşteri bulunamadı.", false);

            Customer.IsDeleted = true;
            Customer.UpdatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"];
            Customer.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Müşteri silindi.", true);
        }
    }
}