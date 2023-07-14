using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Customer.Command.Add
{
    public class CustomerAddCommand : IRequest<Response<Guid>>
    {
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}