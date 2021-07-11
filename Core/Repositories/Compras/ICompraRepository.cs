using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Repositories.Compras
{
    public interface ICompraRepository
    {
        List<CompraEntity> GetCompras();

        void Inserir(CompraEntity compraEntity);

        void Atualizar(CompraEntity compraEntity);

        void Remover(string id);
    }
}
