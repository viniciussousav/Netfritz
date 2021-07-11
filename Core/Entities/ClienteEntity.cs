using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class ClienteEntity : Usuario
    {
        public ClienteEntity(string nome, string email, string senha, DateTime dataCriacao, string cartao, DateTime dataNascimento) : base(nome, email, senha, dataCriacao)
        {
            Cartao = cartao;
            DataNascimento = dataNascimento;
        }

        [Required]
        public string Cartao { get; private set; }

        [Required]
        public DateTime DataNascimento { get; private set; }


        public CompraEntity Compra { get; private set; }
    }
}
