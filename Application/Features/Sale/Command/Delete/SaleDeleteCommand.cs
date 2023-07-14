using Domain.Common;
using MediatR;

namespace Application.Features.Sale.Command.Delete
{
    public class SaleDeleteCommand : IRequest<Response<bool>>
    {
        public Guid SaleId { get; set; }
    }
}