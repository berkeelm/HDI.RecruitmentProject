using MediatR;

namespace Application.Features.Customer.Query.GetById
{
    public class CustomerGetByIdQuery : IRequest<CustomerGetByIdDto>
    {
        public int CustomerId { get; set; }

        public CustomerGetByIdQuery(int CustomerId)
        {
            this.CustomerId = CustomerId;
        }
    }
}
