using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sale.Command.Delete
{
    public class SaleDeleteCommandHandler : IRequestHandler<SaleDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public SaleDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(SaleDeleteCommand request, CancellationToken cancellationToken)
        {
            var Sale = await _HDIContext.Sale.FirstOrDefaultAsync(x => x.Id == request.SaleId && !x.IsDeleted);

            if (Sale == null)
                return new Response<bool>($"Satış bulunamadı.", false);

            Sale.IsDeleted = true;
            Sale.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            Sale.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Satış silindi.", true);
        }
    }
}