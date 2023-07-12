using Application.Features.Users.Query.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Query.Login
{
    public class UsersLoginQuery : IRequest<UsersLoginDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UsersLoginQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}