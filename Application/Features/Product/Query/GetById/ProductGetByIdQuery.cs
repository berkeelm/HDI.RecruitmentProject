using MediatR;

namespace Application.Features.Product.Query.GetById
{
    public class ProductGetByIdQuery : IRequest<ProductGetByIdDto>
    {
        public int ProductId { get; set; }

        public ProductGetByIdQuery(int ProductId)
        {
            this.ProductId = ProductId;
        }
    }
}
