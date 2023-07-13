using MediatR;

namespace Application.Features.Sale.Query.GetById
{
    public class SaleGetByIdQuery : IRequest<SaleGetByIdDto>
    {
        public int SaleId { get; set; }

        public SaleGetByIdQuery(int SaleId)
        {
            this.SaleId = SaleId;
        }
    }
}
