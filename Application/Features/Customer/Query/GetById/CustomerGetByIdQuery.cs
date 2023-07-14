using MediatR;

namespace Application.Features.Customer.Query.GetById
{
    public class CustomerGetByIdQuery : IRequest<CustomerGetByIdDto>
    {
        public Guid CustomerId { get; set; }

        public CustomerGetByIdQuery(Guid CustomerId)
        {
            this.CustomerId = CustomerId;
        }
    }
}
