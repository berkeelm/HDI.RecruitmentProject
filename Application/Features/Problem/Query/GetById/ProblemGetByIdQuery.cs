using MediatR;

namespace Application.Features.Problem.Query.GetById
{
    public class ProblemGetByIdQuery : IRequest<ProblemGetByIdDto>
    {
        public Guid ProblemId { get; set; }

        public ProblemGetByIdQuery(Guid ProblemId)
        {
            this.ProblemId = ProblemId;
        }
    }
}
