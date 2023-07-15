using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Command.Delete
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;
        private readonly ISignalRHelper _signalRHelper;

        public ProductDeleteCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper, ISignalRHelper signalRHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
            _signalRHelper = signalRHelper;
        }

        public async Task<Response<bool>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _HDIContext.User.FirstOrDefault(x => x.Id == (Guid)_httpContextAccessor.HttpContext.Items["User"]);

            var Product = await _HDIContext.Product.FirstOrDefaultAsync(x => x.Id == request.ProductId && !x.IsDeleted);

            if (Product == null)
                return new Response<bool>($"Ürün bulunamadı.", false);

            Product.IsDeleted = true;
            Product.UpdatedUserId = (Guid)_httpContextAccessor.HttpContext.Items["User"];
            Product.UpdatedDate = DateTime.Now;

            await _HDIContext.SaveChangesAsync(cancellationToken);

            await _signalRHelper.SendLog($"[{DateTime.Now.ToString("dd.MM.yyyy HH:mm")}] {currentUser.NameSurname} isimli kullanıcı {Product.Name} isimli ürünü sildi.");

            return new Response<bool>($"Ürün silindi.", true);
        }
    }
}