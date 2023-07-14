using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Sale.Command.Update
{
    public class SaleUpdateCommand : IRequest<Response<bool>>
    {
        public Guid SaleId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public Guid RepairChangeCenterUserId { get; set; }
    }
}