using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Sale.Command.Add
{
    public class SaleAddCommand : IRequest<Response<int>>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
    }
}