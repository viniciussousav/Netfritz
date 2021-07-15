using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Compras;
using Netfritz.Core.Repositories.Fitas;

namespace Netfritz.Controllers
{
    [Route("api")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private Fachada _fachada;

        public CadastroController(IUsuarioRepository usuarioRepository, IFitaRepository fitaRepository, ICompraRepository compraRepository)
        {
            _fachada = new Fachada(usuarioRepository, fitaRepository, compraRepository);
        }

        // Cliente

        [HttpPost("cliente/cadastrar")]
        public IActionResult CadastrarCliente([FromBody] ClienteEntity cliente)
        {
            return _fachada.CadastrarCliente(cliente);
        }
       
        [HttpGet("clientes/{id}")]
        public IActionResult ObterCliente(string id)
        {
            return _fachada.ObterCliente(id);
        }


        [HttpPut("clientes/{id}/atualizar")]
        public IActionResult AtualizarCliente(string id, [FromBody] ClienteEntity cliente)
        {
            return _fachada.AtualizarCliente(id, cliente);
        }

        [HttpDelete("clientes/{id}/remover")]
        public IActionResult RemoverCliente(string id)
        {
            return _fachada.RemoverCliente(id);
        }

        [HttpGet("clientes/{id}/historico-compras")]
        public IActionResult ListarCompras(string id)
        {
            return _fachada.ListarCompras(id);
        }

        [HttpPost("clientes/{id}/comprar")]
        public IActionResult RealizarCompra(string id, [FromBody] string fitaId)
        {
            return _fachada.RealizarCompra(id, fitaId);
        }

        [HttpPut("clientes/{id}/avaliar-compra/{compraId}")]
        public IActionResult AvaliarCompra(string id, string compraId, [FromBody] AvaliacaoEntity avaliacao)
        {
            return _fachada.AvaliarCompra(id, compraId, avaliacao);
        }
    }
}
