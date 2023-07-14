using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sale.Command.Update
{
    public class SaleUpdateCommandHandler : IRequestHandler<SaleUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(SaleUpdateCommand request, CancellationToken cancellationToken)
        {
            var Sale = await _HDIContext.Sale.FirstOrDefaultAsync(x => x.Id == request.SaleId && !x.IsDeleted);

            if (Sale == null)
                return new Response<bool>($"Satış bulunamadı.", false);

            Sale.CustomerId = request.CustomerId;
            Sale.ProductId = request.ProductId;
            Sale.Price = request.Price;
            Sale.RepairChangeCenterUserId = request.RepairChangeCenterUserId;
            Sale.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            Sale.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Satış güncellendi.", true);

            return new Response<bool>($"Satış güncellenirken bir hata oluştu.", false);
        }
    }
}