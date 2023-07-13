using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Features.Customer.Command.Update
{
    public class CustomerUpdateCommand : IRequest<Response<bool>>
    {
        public int CustomerId { get; set; }
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}