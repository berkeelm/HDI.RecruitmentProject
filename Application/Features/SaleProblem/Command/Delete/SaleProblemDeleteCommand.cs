using Domain.Common;
using MediatR;

namespace Application.Features.SaleProblem.Command.Delete
{
    public class SaleProblemDeleteCommand : IRequest<Response<bool>>
    {
        public Guid SaleProblemId { get; set; }
    }
}