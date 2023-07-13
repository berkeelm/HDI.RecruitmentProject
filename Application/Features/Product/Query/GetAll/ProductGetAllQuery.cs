using MediatR;

namespace Application.Features.Product.Query.GetAll
{
    public class ProductGetAllQuery : IRequest<List<ProductGetAllDto>>
    {
        public ProductGetAllQuery()
        {
        }
    }
}