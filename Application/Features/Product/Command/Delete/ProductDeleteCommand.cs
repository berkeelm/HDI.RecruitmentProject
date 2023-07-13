using Domain.Common;
using MediatR;

namespace Application.Features.Product.Command.Delete
{
    public class ProductDeleteCommand : IRequest<Response<bool>>
    {
        public int ProductId { get; set; }
    }
}