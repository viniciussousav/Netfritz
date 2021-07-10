using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class Fita
    {
        public Fita(string titulo, string valor, int ano, string description, List<Avaliacao> listaAvaliacoes)
        {
            Titulo = titulo;
            Valor = valor;
            Ano = ano;
            Description = description;
            ListaAvaliacoes = listaAvaliacoes;
        }

        public Guid Id { get; private set; }

        public string Titulo { get; private set; }

        public string Description { get; private set; }

        public string Valor { get; private set; }

        public int Ano { get; private set; }

        public List<Avaliacao> ListaAvaliacoes { get; private set; }
    }
}
