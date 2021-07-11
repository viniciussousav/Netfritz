using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Fitas;
using System;
using System.Linq;

namespace Netfritz.Controllers
{
    public class FitaController
    {
        private readonly IFitaRepository _fitaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public FitaController(IFitaRepository fitaRepository, IUsuarioRepository usuarioRepository)
        {
            _fitaRepository = fitaRepository;
            _usuarioRepository = usuarioRepository;
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

        public IActionResult ObterFita(string id)
        {
            try
            {
                var fita = _fitaRepository.GetFitas().FirstOrDefault(f => f.Id == id);

                if (fita is null)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }

                return Response.CreateResponse(fita, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível obter a fita", StatusCodes.Status500InternalServerError);
            }
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

        public IActionResult AtualizarFita(string id, FitaEntity fita)
        {
            try
            {
                if(id != fita.Id)
                {
                    return Response.CreateResponse("Os ids são diferentes", StatusCodes.Status400BadRequest);
                }

                var fitaFind = _fitaRepository.GetFitas().FirstOrDefault(f => f.Id == fita.Id);

                if (fitaFind is null)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }

                _fitaRepository.Atualizar(fita);

                return Response.CreateResponse(fita, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível atualizar a fita", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult RemoverFita(string fitaId)
        {
            try
            {
                var fita = _fitaRepository.GetFitas().FirstOrDefault(f => f.Id == fitaId);

                if (fita is null)
                {
                    return Response.CreateResponse("Fita não encontrada", StatusCodes.Status404NotFound);
                }

                _fitaRepository.Remover(fitaId);

                return Response.CreateResponse(fita, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível remover a fita", StatusCodes.Status500InternalServerError);
            }
        }


    }
}
