using MediatR;

namespace Application.Features.Sale.Query.GetById
{
    public class SaleGetByIdQuery : IRequest<SaleGetByIdDto>
    {
        public Guid SaleId { get; set; }

        public SaleGetByIdQuery(Guid SaleId)
        {
            this.SaleId = SaleId;
        }
    }
}
