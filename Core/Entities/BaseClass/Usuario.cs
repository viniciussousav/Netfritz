using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            DataCriacao = DateTime.UtcNow;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; protected set; }

        [Required]
        public string Nome { get; protected set; }

        [Required]
        public string Email { get; protected set; }

        [Required]
        public string Senha { get; protected set; }

        public DateTime DataCriacao { get; protected set;  }
    }
}
