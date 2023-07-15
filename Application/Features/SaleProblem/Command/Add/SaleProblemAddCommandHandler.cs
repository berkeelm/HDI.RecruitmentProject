using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SaleProblem.Command.Add
{
    public class SaleProblemAddCommandHandler : IRequestHandler<SaleProblemAddCommand, Response<Guid?>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public SaleProblemAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<Guid?>> Handle(SaleProblemAddCommand request, CancellationToken cancellationToken)
        {
            var SaleProblem = new Domain.Entities.SaleProblem()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
                SaleId = request.SaleId,
                Price = request.Price,
                ProblemId = request.ProblemId,
            };

            await _HDIContext.SaleProblem.AddAsync(SaleProblem, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid?>($"Ürün arızası kaydedildi.", SaleProblem.Id);
        }
    }
}