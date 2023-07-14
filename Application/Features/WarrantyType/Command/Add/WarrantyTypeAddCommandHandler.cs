using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.WarrantyType.Command.Add
{
    public class WarrantyTypeAddCommandHandler : IRequestHandler<WarrantyTypeAddCommand, Response<Guid>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public WarrantyTypeAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<Guid>> Handle(WarrantyTypeAddCommand request, CancellationToken cancellationToken)
        {
            var WarrantyType = new Domain.Entities.WarrantyType()
            {
                Name = request.Name,
                CreatedDate = DateTime.Now,
                CreatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"],
            };

            await _HDIContext.WarrantyType.AddAsync(WarrantyType, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>($"Garanti Tipi kaydedildi.", WarrantyType.Id);
        }
    }
}