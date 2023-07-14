using MediatR;

namespace Application.Features.SaleWarranty.Query.GetById
{
    public class SaleWarrantyGetByIdQuery : IRequest<SaleWarrantyGetByIdDto>
    {
        public Guid SaleWarrantyId { get; set; }

        public SaleWarrantyGetByIdQuery(Guid SaleWarrantyId)
        {
            this.SaleWarrantyId = SaleWarrantyId;
        }
    }
}
