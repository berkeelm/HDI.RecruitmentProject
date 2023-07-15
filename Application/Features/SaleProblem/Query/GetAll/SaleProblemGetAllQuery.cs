using MediatR;

namespace Application.Features.SaleProblem.Query.GetAll
{
    public class SaleProblemGetAllQuery : IRequest<List<SaleProblemGetAllDto>>
    {
        public Guid? SaleId { get; set; }

        public SaleProblemGetAllQuery(Guid? SaleId)
        {
            this.SaleId = SaleId;
        }

        public SaleProblemGetAllQuery()
        {
        }
    }
}