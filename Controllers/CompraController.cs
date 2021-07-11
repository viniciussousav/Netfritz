using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories.Compras;
using System;
using System.Linq;

namespace Netfritz.Controllers
{
    public class CompraController
    {
        private static ICompraRepository _compraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public IActionResult RealizarCompra(CompraEntity compra)
        {
            try
            {
                _compraRepository.Inserir(compra);
                return Response.CreateResponse(compra, StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível realizar a compra", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult AvaliarCompra(string id, AvaliacaoEntity avaliacao)
        {
            try
            {
                var compra = _compraRepository.GetCompras().FirstOrDefault(c => c.Id == id);

                if(compra is null)
                {
                    return Response.CreateResponse("A compra não existe", StatusCodes.Status404NotFound);
                }

                compra.AvaliarCompra(avaliacao.Nota, avaliacao.Comentario);

                _compraRepository.Atualizar(compra);

                return Response.CreateResponse("Compra avaliada com sucesso", StatusCodes.Status200OK);

            }
            catch (Exception)
            {

                return Response.CreateResponse("Não foi possível avaliar a compra", StatusCodes.Status500InternalServerError);
            }
        }
    }
}
