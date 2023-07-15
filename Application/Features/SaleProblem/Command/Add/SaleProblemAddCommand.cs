using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.SaleProblem.Command.Add
{
    public class SaleProblemAddCommand : IRequest<Response<Guid?>>
    {
        public Guid SaleId { get; set; }
        public Guid ProblemId { get; set; }
        public decimal Price { get; set; }
    }
}