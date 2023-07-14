using Domain.Common;
using MediatR;

namespace Application.Features.Problem.Command.Delete
{
    public class ProblemDeleteCommand : IRequest<Response<bool>>
    {
        public Guid ProblemId { get; set; }
    }
}