using MediatR;

namespace Application.Features.SaleWarranty.Query.GetAll
{
    public class SaleWarrantyGetAllQuery : IRequest<List<SaleWarrantyGetAllDto>>
    {
        public Guid? SaleId { get; set; }

        public SaleWarrantyGetAllQuery(Guid SaleId)
        {
            this.SaleId = SaleId;
        }

        public SaleWarrantyGetAllQuery()
        {
        }
    }
}