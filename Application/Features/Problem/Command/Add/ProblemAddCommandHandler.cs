using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Problem.Command.Add
{
    public class ProblemAddCommandHandler : IRequestHandler<ProblemAddCommand, Response<Guid?>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public ProblemAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<Guid?>> Handle(ProblemAddCommand request, CancellationToken cancellationToken)
        {
            var Problem = new Domain.Entities.Problem()
            {
                Name = request.Name,
                WarrantyTypeId = request.WarrantyTypeId,
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
            };

            await _HDIContext.Problem.AddAsync(Problem, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid?>($"Arıza kaydedildi.", Problem.Id);
        }
    }
}