using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Problem.Command.Add
{
    public class ProblemAddCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public int WarrantyTypeId { get; set; }
    }
}