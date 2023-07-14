using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.WarrantyType.Command.Delete
{
    public class WarrantyTypeDeleteCommandHandler : IRequestHandler<WarrantyTypeDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public WarrantyTypeDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(WarrantyTypeDeleteCommand request, CancellationToken cancellationToken)
        {
            var WarrantyType = await _HDIContext.WarrantyType.FirstOrDefaultAsync(x => x.Id == request.WarrantyTypeId && !x.IsDeleted);

            if (WarrantyType == null)
                return new Response<bool>($"Garanti Tipi bulunamadı.", false);

            WarrantyType.IsDeleted = true;
            WarrantyType.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            WarrantyType.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Garanti Tipi silindi.", true);
        }
    }
}