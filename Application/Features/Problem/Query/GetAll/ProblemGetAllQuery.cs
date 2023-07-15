using MediatR;

namespace Application.Features.Problem.Query.GetAll
{
    public class ProblemGetAllQuery : IRequest<List<ProblemGetAllDto>>
    {
        public Guid? SaleId { get; set; } = null;

        public ProblemGetAllQuery(Guid? SaleId)
        {
            this.SaleId = SaleId;
        }

        public ProblemGetAllQuery()
        {
        }
    }
}