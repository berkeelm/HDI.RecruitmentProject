using MediatR;

namespace Application.Features.Customer.Query.GetAll
{
    public class CustomerGetAllQuery : IRequest<List<CustomerGetAllDto>>
    {
        public CustomerGetAllQuery()
        {
        }
    }
}