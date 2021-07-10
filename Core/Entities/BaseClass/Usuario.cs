using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public abstract class Usuario
    {
        protected Usuario(string nome, string email, string senha, DateTime dataCriacao)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCriacao = dataCriacao;
        }

        public Guid Id { get; protected set; }

        public string Nome { get; protected set; }

        public string Email { get; protected set; }

        public string Senha { get; protected set; }

        public DateTime DataCriacao { get; protected set;  }
    }
}
