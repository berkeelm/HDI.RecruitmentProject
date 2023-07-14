using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.SaleWarranty.Command.Add
{
    public class SaleWarrantyAddCommand : IRequest<Response<Guid>>
    {
        public Guid SaleId { get; set; }
        public Guid WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}