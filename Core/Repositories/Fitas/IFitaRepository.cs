using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Repositories.Fitas
{
    public interface IFitaRepository
    {
        List<FitaEntity> GetFitas();

        void Inserir(FitaEntity fita);

        void Atualizar(FitaEntity fita);

        void Remover(string fita);

    }
}
