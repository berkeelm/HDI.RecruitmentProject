using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Problem.Command.Update
{
    public class ProblemUpdateCommandHandler : IRequestHandler<ProblemUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProblemUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(ProblemUpdateCommand request, CancellationToken cancellationToken)
        {
            var Problem = await _HDIContext.Problem.FirstOrDefaultAsync(x => x.Id == request.ProblemId && !x.IsDeleted);

            if (Problem == null)
                return new Response<bool>($"Arıza bulunamadı.", false);

            Problem.Name = request.Name;
            Problem.WarrantyTypeId= request.WarrantyTypeId;
            Problem.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            Problem.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Arıza güncellendi.", true);

            return new Response<bool>($"Arıza güncellenirken bir hata oluştu.", false);
        }
    }
}