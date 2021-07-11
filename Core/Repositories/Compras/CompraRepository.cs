using Netfritz.Context;
using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Repositories.Compras
{
    public class CompraRepository : ICompraRepository
    {
        private readonly AppDbContext _context;

        public CompraRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<CompraEntity> GetCompras()
        {
            return _context.Compras.ToList();
        }

        public void Inserir(CompraEntity compra)
        {
            _context.Compras.Add(compra);
            _context.SaveChanges();
        }

        public void Atualizar(CompraEntity compra)
        {
            _context.Compras.Update(compra);
            _context.SaveChanges();
        }
        
        public void Remover(string id)
        {
            var compra = _context.Compras.FirstOrDefault(c => c.Id == id);
            _context.Compras.Update(compra);
            _context.SaveChanges();
        }
    }
}
