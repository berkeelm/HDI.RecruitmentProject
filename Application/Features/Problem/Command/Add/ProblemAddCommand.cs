using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Problem.Command.Add
{
    public class ProblemAddCommand : IRequest<Response<Guid?>>
    {
        public string Name { get; set; }
        public Guid WarrantyTypeId { get; set; }
    }
}