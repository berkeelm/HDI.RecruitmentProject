﻿using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Customer.Command.Add
{
    public class CustomerAddCommandHandler : IRequestHandler<CustomerAddCommand, Response<Guid?>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public CustomerAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<Guid?>> Handle(CustomerAddCommand request, CancellationToken cancellationToken)
        {
            var Customer = new Domain.Entities.Customer()
            {
                Address = request.Address,
                Mail = request.Mail,
                NameSurname = request.NameSurname,
                Phone = request.Phone,
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
            };

            await _HDIContext.Customer.AddAsync(Customer, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid?>($"Müşteri kaydedildi.", Customer.Id);
        }
    }
}