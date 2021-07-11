using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    [Owned]
    public class AvaliacaoEntity
    {
        public AvaliacaoEntity(int nota, string comentario)
        {
            Nota = nota;
            Comentario = comentario;
        }

        public int Nota { get; private set; }

        public string Comentario { get; private set; }


    }
}
