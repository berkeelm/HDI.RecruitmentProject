using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Product.Command.Update
{
    public class ProductUpdateCommand : IRequest<Response<bool>>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PhotoPath { get; set; }
    }
}