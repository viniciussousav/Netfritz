using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class Administrador : Usuario
    {
        public Administrador(string nome, string email, string senha, DateTime dataCriacao) : base(nome, email, senha, dataCriacao)
        {

        }
    }
}
