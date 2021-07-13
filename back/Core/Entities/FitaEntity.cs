using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class FitaEntity
    {
        public FitaEntity(string titulo, decimal valor, int ano, string descricao)
        {
            Titulo = titulo;
            Valor = valor;
            Ano = ano;
            Descricao = descricao;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; private set; }

        [Required]
        public string Titulo { get; private set; }

        [Required]
        public string Descricao { get; private set; }

        [Required]
        public decimal Valor { get; private set; }

        [Required]
        public int Ano { get; private set; }
        
        public string imagemUrl { get;  set; }
        
    }
}
