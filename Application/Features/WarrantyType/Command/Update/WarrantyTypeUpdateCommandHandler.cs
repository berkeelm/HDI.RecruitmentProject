using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WarrantyType.Command.Update
{
    public class WarrantyTypeUpdateCommandHandler : IRequestHandler<WarrantyTypeUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WarrantyTypeUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(WarrantyTypeUpdateCommand request, CancellationToken cancellationToken)
        {
            var WarrantyType = await _HDIContext.WarrantyType.FirstOrDefaultAsync(x => x.Id == request.WarrantyTypeId && !x.IsDeleted);

            if (WarrantyType == null)
                return new Response<bool>($"Garanti Tipi bulunamadı.", false);

            WarrantyType.Name = request.Name;
            WarrantyType.UpdatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"];
            WarrantyType.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Garanti Tipi güncellendi.", true);

            return new Response<bool>($"Garanti Tipi güncellenirken bir hata oluştu.", false);
        }
    }
}