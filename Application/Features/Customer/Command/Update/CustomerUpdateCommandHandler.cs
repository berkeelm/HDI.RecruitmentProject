using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Customer.Command.Update
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var Customer = await _HDIContext.Customer.FirstOrDefaultAsync(x => x.Id == request.CustomerId && !x.IsDeleted);

            if (Customer == null)
                return new Response<bool>($"Müşteri bulunamadı.", false);

            Customer.NameSurname = request.NameSurname;
            Customer.Address = request.Address;
            Customer.Phone = request.Phone;
            Customer.Mail = request.Mail;
            Customer.UpdatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"];
            Customer.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Müşteri güncellendi.", true);

            return new Response<bool>($"Müşteri güncellenirken bir hata oluştu.", false);
        }
    }
}