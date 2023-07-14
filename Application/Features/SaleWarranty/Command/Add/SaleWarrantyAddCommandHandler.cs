using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.SaleWarranty.Command.Add
{
    public class SaleWarrantyAddCommandHandler : IRequestHandler<SaleWarrantyAddCommand, Response<Guid>>
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

        public async Task<Response<Guid>> Handle(SaleWarrantyAddCommand request, CancellationToken cancellationToken)
        {
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

            return new Response<Guid>($"Garanti kaydedildi.", SaleWarranty.Id);
        }
    }
}