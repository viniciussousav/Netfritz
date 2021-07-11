using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class AdministradorEntity : Usuario
    {
        public AdministradorEntity(string nome, string email, string senha, DateTime dataCriacao) : base(nome, email, senha, dataCriacao) 
        {
        
        }

        
    }
}
