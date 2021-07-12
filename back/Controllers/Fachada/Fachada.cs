using Microsoft.AspNetCore.Mvc;
using Netfritz.Context;
using Netfritz.Core.Entities;
using Netfritz.Core.Models.BaseClass;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Compras;
using Netfritz.Core.Repositories.Fitas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Netfritz.Controllers
{
    [ApiController]
    [Route("api")]
    public class Fachada : ControllerBase
    {

        private readonly AuthController _authController;
        private readonly CadastroController _cadastroController;
        private readonly FitaController _fitaController;
        private readonly CompraController _compraController;
        
        public Fachada(IUsuarioRepository usuarioRepository, IFitaRepository fitaRepository, ICompraRepository compraRepository)
        {
            _authController = new AuthController(usuarioRepository);

            _cadastroController = new CadastroController(usuarioRepository);
            _fitaController = new FitaController(fitaRepository, usuarioRepository);
            _compraController = new CompraController(compraRepository, usuarioRepository);
        }

        // Login

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            return _authController.Login(login.Email, login.Senha);
        }

        // Cliente
    
        [HttpGet("clientes/{id}")]
        public IActionResult ObterCliente(string id)
        {
            return _cadastroController.ObterCliente(id);
        }

        [HttpPost("cliente/cadastrar")]
        public IActionResult CadastrarCliente([FromBody] ClienteEntity cliente)
        {
            return _cadastroController.CadastrarCliente(cliente);
        }

        [HttpPut("clientes/{id}/atualizar")]
        public IActionResult AtualizarCliente(string id, [FromBody] ClienteEntity cliente)
        {
            return _cadastroController.AtualizarCliente(id, cliente);
        }

        [HttpDelete("clientes/{id}/remover")]
        public IActionResult RemoverCliente(string id)
        {
            return _cadastroController.RemoverCliente(id);
        }

        [HttpGet("clientes/{id}/historico-compras")]
        public IActionResult ListarCompras(string id)
        {
            return _compraController.ListarComprasCliente(id);
        }

        [HttpPost("clientes/{id}/comprar")]
        public IActionResult RealizarCompra(string id, [FromBody] string fitaId)
        {
            return _compraController.RealizarCompra(id, fitaId);
        }

        [HttpPut("clientes/{id}/avaliar-compra/{compraId}")]
        public IActionResult AvaliarCompra(string id, string compraId, [FromBody] AvaliacaoEntity avaliacao)
        {
            return _compraController.AvaliarCompra(id, compraId, avaliacao);
        }

        // Administrador 

        [HttpGet("admin/{id}")]
        public IActionResult ObterAdministrador(string id)
        {
            return _cadastroController.ObterAdministrador(id);
        }
        
        [HttpPost("admin/cadastrar-admin")]
        public IActionResult CadastrarAdministrador([FromBody] AdministradorEntity administrador)
        {
            return _cadastroController.CadastrarAdministrador(administrador);
        }

        [HttpGet("admin/visualizar-vendas")]
        public IActionResult VisualiarVendas()
        {
            return _compraController.ListarCompras();
        }

        [HttpPost("admin/cadastrar-fita")]
        public IActionResult CadastrarFita([FromBody] FitaEntity fita)
        {
            return _fitaController.CadastrarFita(fita);
        }

        [HttpPut("admin/atualizar-fita/{fitaId}")]
        public IActionResult AtualizarFita(string fitaId, [FromBody] FitaEntity fita)
        {
            return _fitaController.AtualizarFita(fitaId, fita);
        }

        [HttpDelete("admin/remover-fita/{fitaId}")]
        public IActionResult RemoverFita( string fitaId)
        {
            return _fitaController.RemoverFita(fitaId);
        }

        // Fitas

        [HttpGet("fitas")]
        public IActionResult PesquisarFitas(string busca)
        {
            return _fitaController.PesquisarFitas(busca);
        }
        
        [HttpGet("fitas/{id}")]
        public IActionResult PesquisarFita(string id)
        {
            return _fitaController.ObterFita(id);
        }
    }
}
