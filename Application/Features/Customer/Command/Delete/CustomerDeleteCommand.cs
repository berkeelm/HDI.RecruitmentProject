using Domain.Common;
using MediatR;

namespace Application.Features.Customer.Command.Delete
{
    public class CustomerDeleteCommand : IRequest<Response<bool>>
    {
        public Guid CustomerId { get; set; }
    }
}