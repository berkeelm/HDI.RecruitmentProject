using Domain.Common;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Command.Delete
{
    public class UserDeleteCommand : IRequest<Response<bool>>
    {
        public Guid UserId { get; set; }
    }
}
