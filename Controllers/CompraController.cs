using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Compras;
using System;
using System.Linq;

namespace Netfritz.Controllers
{
    public class CompraController
    {
        private readonly ICompraRepository _compraRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CompraController(ICompraRepository compraRepository, IUsuarioRepository usuarioRepository)
        {
            _compraRepository = compraRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult ListarCompras(string adminId)
        {
            var admin = _usuarioRepository.GetAdministrador(adminId);

            if (admin is null)
            {
                return Response.CreateResponse("Administrador não encontrado", StatusCodes.Status401Unauthorized);
            }

            try
            {
                var compras = _compraRepository.GetCompras();

                return Response.CreateResponse(compras, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível listar todas as compras", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult ListarComprasCliente(string clienteId)
        {
            try
            {

                var cliente = _usuarioRepository.GetCliente(clienteId);

                if(cliente is null)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                var compras = _compraRepository.GetCompras().Where(c => c.ClienteEntityId == clienteId);

                return Response.CreateResponse(compras, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível listar todas as compras", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult RealizarCompra(string clienteId, string fitaId)
        {
            try
            {
                var cliente = _usuarioRepository.GetCliente(clienteId);

                if (cliente is null)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                var compra = new CompraEntity(clienteId, fitaId);

                _compraRepository.Inserir(compra);
                return Response.CreateResponse(compra, StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível realizar a compra", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult AvaliarCompra(string idCliente, string idCompra, [FromBody] AvaliacaoEntity avaliacao)
        {
            try
            {
                var compra = _compraRepository.GetCompras()
                    .FirstOrDefault(c =>
                        c.ClienteEntityId == idCliente &&
                        c.Id == idCompra);

                if (compra is null)
                {
                    return Response.CreateResponse("Compra não encontrada", StatusCodes.Status404NotFound);
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
