﻿using Application.Common.Interfaces;
using Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Product.Command.Add
{
    public class ProductAddCommandHandler : IRequestHandler<ProductAddCommand, Response<int>>
    {
        private readonly IHDIContext _HDIContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICryptographyHelper _cryptographyHelper;

        public ProductAddCommandHandler(IHDIContext HDIContext, IHttpContextAccessor httpContextAccessor, ICryptographyHelper cryptographyHelper)
        {
            _HDIContext = HDIContext;
            _httpContextAccessor = httpContextAccessor;
            _cryptographyHelper = cryptographyHelper;
        }

        public async Task<Response<int>> Handle(ProductAddCommand request, CancellationToken cancellationToken)
        {
            var Product = new Domain.Entities.Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                PhotoPath = request.PhotoPath,
                CreatedDate = DateTime.Now,
                CreatedUserId = (int)_httpContextAccessor.HttpContext.Items["User"],
            };

            await _HDIContext.Product.AddAsync(Product, cancellationToken);

            await _HDIContext.SaveChangesAsync(cancellationToken);

            return new Response<int>($"Ürün kaydedildi.", Product.Id);
        }
    }
}