using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleWarranty.Command.Delete
{
    public class SaleWarrantyDeleteCommandHandler : IRequestHandler<SaleWarrantyDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public SaleWarrantyDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(SaleWarrantyDeleteCommand request, CancellationToken cancellationToken)
        {
            var SaleWarranty = await _HDIContext.SaleWarranty.FirstOrDefaultAsync(x => x.Id == request.SaleWarrantyId && !x.IsDeleted);

            if (SaleWarranty == null)
                return new Response<bool>($"Garanti bulunamadı.", false);

            SaleWarranty.IsDeleted = true;
            SaleWarranty.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            SaleWarranty.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Garanti silindi.", true);
        }
    }
}