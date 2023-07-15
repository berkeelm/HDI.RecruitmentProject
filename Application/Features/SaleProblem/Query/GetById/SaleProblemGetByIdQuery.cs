using MediatR;

namespace Application.Features.SaleProblem.Query.GetById
{
    public class SaleProblemGetByIdQuery : IRequest<SaleProblemGetByIdDto>
    {
        public Guid SaleProblemId { get; set; }

        public SaleProblemGetByIdQuery(Guid SaleProblemId)
        {
            this.SaleProblemId = SaleProblemId;
        }
    }
}
