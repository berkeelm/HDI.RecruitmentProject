using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Problem.Command.Update
{
    public class ProblemUpdateCommand : IRequest<Response<bool>>
    {
        public int ProblemId { get; set; }
        public string Name { get; set; }
        public int WarrantyTypeId { get; set; }
    }
}