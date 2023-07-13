using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Command.Update
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Response<bool>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductUpdateCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<bool>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var Product = await _HDIContext.Product.FirstOrDefaultAsync(x => x.Id == request.ProductId && !x.IsDeleted);

            if (Product == null)
                return new Response<bool>($"Ürün bulunamadı.", false);

            Product.Name = request.Name;
            Product.Description = request.Description;
            Product.Price = request.Price;
            Product.PhotoPath = request.PhotoPath;
            Product.UpdatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"];
            Product.UpdatedDate = DateTime.Now;

            int numberOfUpdated = await _HDIContext.SaveChangesAsync(cancellationToken);

            if (numberOfUpdated > 0)
                return new Response<bool>($"Ürün güncellendi.", true);

            return new Response<bool>($"Ürün güncellenirken bir hata oluştu.", false);
        }
    }
}