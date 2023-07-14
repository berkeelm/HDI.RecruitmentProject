using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Problem.Command.Delete
{
    public class ProblemDeleteCommandHandler : IRequestHandler<ProblemDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public ProblemDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<bool>> Handle(ProblemDeleteCommand request, CancellationToken cancellationToken)
        {
            var Problem = await _HDIContext.Problem.FirstOrDefaultAsync(x => x.Id == request.ProblemId && !x.IsDeleted);

            if (Problem == null)
                return new Response<bool>($"Arıza bulunamadı.", false);

            Problem.IsDeleted = true;
            Problem.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            Problem.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<bool>($"Arıza silindi.", true);
        }
    }
}