using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleProblem.Command.Update
{
    public class SaleProblemUpdateCommandHandler : IRequestHandler<SaleProblemUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleProblemUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(SaleProblemUpdateCommand request, CancellationToken cancellationToken)
        {
            var SaleProblem = await _HDIContext.SaleProblem.FirstOrDefaultAsync(x => x.Id == request.SaleProblemId && !x.IsDeleted);

            if (SaleProblem == null)
                return new Response<bool>($"Ürün arızası bulunamadı.", false);

            SaleProblem.SaleId = SaleProblem.SaleId;
            SaleProblem.ProblemId = SaleProblem.ProblemId;
            SaleProblem.Price = SaleProblem.Price;
            SaleProblem.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            SaleProblem.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Ürün arızası güncellendi.", true);

            return new Response<bool>($"Ürün arızası güncellenirken bir hata oluştu.", false);
        }
    }
}