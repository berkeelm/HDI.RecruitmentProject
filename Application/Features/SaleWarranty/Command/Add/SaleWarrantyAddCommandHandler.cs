﻿using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleWarranty.Command.Add
{
    public class SaleWarrantyAddCommandHandler : IRequestHandler<SaleWarrantyAddCommand, Response<Guid?>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public SaleWarrantyAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<Guid?>> Handle(SaleWarrantyAddCommand request, CancellationToken cancellationToken)
        {
            var control = await _HDIContext.SaleWarranty.FirstOrDefaultAsync(x => x.SaleId == request.SaleId && DateTime.Now >= x.StartDate && DateTime.Now <= x.EndDate && !x.IsDeleted);

            if (control != null)
            {
                return new Response<Guid?>($"Ürünün zaten aktif bir garantisi bulunmaktadır.", (Guid?)null);
            }

            var SaleWarranty = new Domain.Entities.SaleWarranty()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
                EndDate = request.EndDate.AddDays(1).AddSeconds(-1),
                SaleId = request.SaleId,
                StartDate = request.StartDate,
                WarrantyTypeId = request.WarrantyTypeId
            };

            await _HDIContext.SaleWarranty.AddAsync(SaleWarranty, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid?>($"Garanti kaydedildi.", SaleWarranty.Id);
        }
    }
}