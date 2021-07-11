using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories.Fitas;
using System;
using System.Linq;

namespace Netfritz.Controllers
{
    public class FitaController
    {
        private readonly IFitaRepository _fitaRepository;

        public FitaController(IFitaRepository fitaRepository)
        {
            _fitaRepository = fitaRepository;
        }

        public IActionResult CadastrarFita(FitaEntity fita)
        {
            try
            {
                var checkFitaTitulo = _fitaRepository.GetFitas().Any(f => f.Titulo == fita.Titulo);

                if (checkFitaTitulo)
                {
                    return Response.CreateResponse("Já existe uma fita cadastrada de mesmo nome", StatusCodes.Status409Conflict);
                }

                _fitaRepository.Inserir(fita);

                return Response.CreateResponse(fita, StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível cadastrar a fita", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult PesquisarFitas(string busca)
        {
            try
            {
                var resultado = _fitaRepository.GetFitas().ToList();

                if (!string.IsNullOrEmpty(busca))
                {
                    resultado = resultado
                        .Where(f => f.Titulo.ToLower().Contains(busca.ToLower()))
                        .ToList();
                }

                return Response.CreateResponse(resultado, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível realizar a pesquisa", StatusCodes.Status500InternalServerError);
            }
        }



    }
}
