﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Query.Login
{
    public class UsersLoginDto
    {
        public string Token { get; set; }
        public DateTime Expire { get; set; }
    }
}
