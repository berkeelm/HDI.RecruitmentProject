using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Product.Command.Add
{
    public class ProductAddCommand : IRequest<Response<Guid>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}