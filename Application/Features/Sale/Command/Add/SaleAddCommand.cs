using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Sale.Command.Add
{
    public class SaleAddCommand : IRequest<Response<Guid?>>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public Guid RepairChangeCenterUserId { get; set; }
    }
}