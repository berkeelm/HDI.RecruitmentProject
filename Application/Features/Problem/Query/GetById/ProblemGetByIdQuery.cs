using MediatR;

namespace Application.Features.Problem.Query.GetById
{
    public class ProblemGetByIdQuery : IRequest<ProblemGetByIdDto>
    {
        public int ProblemId { get; set; }

        public ProblemGetByIdQuery(int ProblemId)
        {
            this.ProblemId = ProblemId;
        }
    }
}
