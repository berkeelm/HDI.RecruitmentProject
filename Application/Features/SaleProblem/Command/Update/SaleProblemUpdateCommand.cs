using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.SaleProblem.Command.Update
{
    public class SaleProblemUpdateCommand : IRequest<Response<bool>>
    {
        public Guid SaleProblemId { get; set; }
        public Guid SaleId { get; set; }
        public Guid ProblemId { get; set; }
        public decimal Price { get; set; }
    }
}