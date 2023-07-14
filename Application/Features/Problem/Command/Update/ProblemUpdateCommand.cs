using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Problem.Command.Update
{
    public class ProblemUpdateCommand : IRequest<Response<bool>>
    {
        public Guid ProblemId { get; set; }
        public string Name { get; set; }
        public Guid WarrantyTypeId { get; set; }
    }
}