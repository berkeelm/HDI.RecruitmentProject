using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Query.Login
{
    public class UserLoginDto
    {
        public string Token { get; set; }
        public DateTime Expire { get; set; }
        public string NameSurname { get; set; }
        public UserType UserType { get; set; }
    }
}
