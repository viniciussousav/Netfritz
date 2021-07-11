using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Entities
{
    public class CompraEntity
    {
        public CompraEntity(string clienteEntityId, string fitaEntityId)
        {
            ClienteEntityId = clienteEntityId;
            FitaEntityId = fitaEntityId;
            DataCompra = DateTime.UtcNow;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string ClienteEntityId { get; private set; }
        public ClienteEntity ClienteEntitiy { get; set; }

        [Required]
        public string FitaEntityId { get; private set; }
        public FitaEntity FitaEntity { get; private set; }

        public AvaliacaoEntity Avaliacao { get; private set; }

        public DateTime DataCompra { get; private set; }

        public void AvaliarCompra(int nota, string comentario)
        {
            if (nota < 0 && 5 < nota)
            {
                throw new Exception("A nota deve ser entre 0 e 5");
            }

            Avaliacao = new AvaliacaoEntity(nota, comentario);

        }

    }
}
