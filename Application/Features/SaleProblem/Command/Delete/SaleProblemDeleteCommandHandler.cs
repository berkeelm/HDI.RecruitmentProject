using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleProblem.Command.Delete
{
    public class SaleProblemDeleteCommandHandler : IRequestHandler<SaleProblemDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public SaleProblemDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(SaleProblemDeleteCommand request, CancellationToken cancellationToken)
        {
            var SaleProblem = await _HDIContext.SaleProblem.FirstOrDefaultAsync(x => x.Id == request.SaleProblemId && !x.IsDeleted);

            if (SaleProblem == null)
                return new Response<bool>($"Ürün arızası bulunamadı.", false);

            SaleProblem.IsDeleted = true;
            SaleProblem.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            SaleProblem.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Ürün arızası silindi.", true);
        }
    }
}