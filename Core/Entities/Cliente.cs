using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class Cliente : Usuario
    {
        public Cliente(string nome, string email, string senha, DateTime dataCriacao, string cartao, DateTime dataNascimento) : base(nome, email, senha, dataCriacao)
        {
            Cartao = cartao;
            DataNascimento = dataNascimento;
            Compras = new List<Compra>();
        }

        public string Cartao { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public List<Compra> Compras { get; private set; }

        public Compra Compra { get; private set; }
    }
}
