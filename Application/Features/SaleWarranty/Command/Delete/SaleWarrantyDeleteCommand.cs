using Domain.Common;
using MediatR;

namespace Application.Features.SaleWarranty.Command.Delete
{
    public class SaleWarrantyDeleteCommand : IRequest<Response<bool>>
    {
        public Guid SaleWarrantyId { get; set; }
    }
}