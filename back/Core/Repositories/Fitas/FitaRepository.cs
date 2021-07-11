using Microsoft.EntityFrameworkCore;
using Netfritz.Context;
using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Repositories.Fitas
{
    public class FitaRepository : IFitaRepository
    {
        public AppDbContext _context;

        public FitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<FitaEntity> GetFitas()
        {
            return _context.Fitas
                .AsNoTracking()
                .ToList();
        }

        public void Inserir(FitaEntity fita)
        {
            _context.Fitas.Add(fita);
            _context.SaveChanges();
        }

        public void Atualizar(FitaEntity fita)
        {
            _context.Fitas.Update(fita);
            _context.SaveChanges();
        }

        public void Remover(string id)
        {
            var fita = _context.Fitas.FirstOrDefault(f => f.Id == id);
            _context.Fitas.Remove(fita);
            _context.SaveChanges();

        }
    }
}
