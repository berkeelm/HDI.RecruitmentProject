using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Sale.Command.Add
{
    public class SaleAddCommandHandler : IRequestHandler<SaleAddCommand, Response<Guid?>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public SaleAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<Guid?>> Handle(SaleAddCommand request, CancellationToken cancellationToken)
        {
            var Sale = new Domain.Entities.Sale()
            {
                CustomerId = request.CustomerId,
                Price = request.Price,
                ProductId = request.ProductId,
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
                RepairChangeCenterUserId = request.RepairChangeCenterUserId,
            };

            await _HDIContext.Sale.AddAsync(Sale, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid?>($"Satış kaydedildi.", Sale.Id);
        }
    }
}