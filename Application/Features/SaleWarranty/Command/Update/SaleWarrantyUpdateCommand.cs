using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.SaleWarranty.Command.Update
{
    public class SaleWarrantyUpdateCommand : IRequest<Response<bool>>
    {
        public Guid SaleWarrantyId { get; set; }
        public Guid WarrantyTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}