using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleWarranty.Command.Update
{
    public class SaleWarrantyUpdateCommandHandler : IRequestHandler<SaleWarrantyUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleWarrantyUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(SaleWarrantyUpdateCommand request, CancellationToken cancellationToken)
        {
            var SaleWarranty = await _HDIContext.SaleWarranty.FirstOrDefaultAsync(x => x.Id == request.SaleWarrantyId && !x.IsDeleted);

            if (SaleWarranty == null)
                return new Response<bool>($"Garanti bulunamadı.", false);

            SaleWarranty.WarrantyTypeId = request.WarrantyTypeId;
            SaleWarranty.StartDate = request.StartDate;
            SaleWarranty.EndDate = request.EndDate.AddDays(1).AddSeconds(-1);
            SaleWarranty.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            SaleWarranty.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Garanti güncellendi.", true);

            return new Response<bool>($"Garanti güncellenirken bir hata oluştu.", false);
        }
    }
}