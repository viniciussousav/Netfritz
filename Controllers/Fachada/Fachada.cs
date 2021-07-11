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
    
        [HttpPost("clientes/cadastrar")]
        public IActionResult CadastrarCliente([FromBody] ClienteEntity cliente)
        {
            return _cadastroController.CadastrarCliente(cliente);
        }

        [HttpGet("clientes/{id}")]
        public IActionResult ObterCliente(string id)
        {
            return _cadastroController.ObterCliente(id);
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

        // Administrador 

        [HttpGet("admin/{id}")]
        public IActionResult ObterAdministrador(string id)
        {
            return _cadastroController.ObterAdministrador(id);
        }
        
        [HttpPost("admin/{id}/cadastrar-admin")]
        public IActionResult CadastrarAdministrador(string id, [FromBody] AdministradorEntity administrador)
        {
            return _cadastroController.CadastrarAdministrador(id, administrador);
        }

        [HttpGet("admin/{id}/visualizar-vendas")]
        public IActionResult VisualiarVendas(string id)
        {
            return _compraController.ListarCompras(id);
        }

        [HttpPost("admin/{id}/cadastrar-fita")]
        public IActionResult CadastrarFita(string id, [FromBody] FitaEntity fita)
        {
            return _fitaController.CadastrarFita(id, fita);
        }

        [HttpPut("admin/{id}/atualizar-fita")]
        public IActionResult AtualizarFita(string id, [FromBody] FitaEntity fita)
        {
            return _fitaController.AtualizarFita(id, fita);
        }

        [HttpDelete("admin/{id}/remover-fita/{fitaId}")]
        public IActionResult RemoverFita(string id, string fitaId)
        {
            return _fitaController.RemoverFita(id, fitaId);
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
