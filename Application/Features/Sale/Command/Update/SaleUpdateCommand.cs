using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Sale.Command.Update
{
    public class SaleUpdateCommand : IRequest<Response<bool>>
    {
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int RepairChangeCenterUserId { get; set; }
    }
}