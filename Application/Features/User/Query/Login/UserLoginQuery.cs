using Application.Features.User.Query.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Query.Login
{
    public class UserLoginQuery : IRequest<UserLoginDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginQuery()
        {
        }

        public UserLoginQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}