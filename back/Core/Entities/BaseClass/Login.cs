using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Models.BaseClass
{
    public class Login
    {
        public Login(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }

        public string Senha { get; private set; }
    }
}
