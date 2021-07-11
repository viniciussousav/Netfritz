using System;
using System.ComponentModel.DataAnnotations;

namespace Netfritz.Core.Entities
{
    public class ClienteEntity : Usuario
    {
        public ClienteEntity(string nome, string email, string senha, string cartao, DateTime dataNascimento) : base(nome, email, senha)
        {
            Cartao = cartao;
            DataNascimento = dataNascimento;
        }

        [Required]
        public string Cartao { get; private set; }

        [Required]
        public DateTime DataNascimento { get; private set; }

    }
}
