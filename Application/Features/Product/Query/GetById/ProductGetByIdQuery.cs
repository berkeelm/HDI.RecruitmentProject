using MediatR;

namespace Application.Features.Product.Query.GetById
{
    public class ProductGetByIdQuery : IRequest<ProductGetByIdDto>
    {
        public Guid ProductId { get; set; }

        public ProductGetByIdQuery(Guid ProductId)
        {
            this.ProductId = ProductId;
        }
    }
}
