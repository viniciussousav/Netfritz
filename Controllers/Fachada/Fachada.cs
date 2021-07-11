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
            _fitaController = new FitaController(fitaRepository);
            _compraController = new CompraController(compraRepository);
        }

        /*
         * LOGIN
         */

        [HttpPost("cliente/login")]
        public IActionResult Login([FromBody] Login login)
        {
            return _authController.Login(login.Email, login.Senha);
        }

        /*
         * CLIENTE
         */


        [HttpPost("cliente/cadastrar")]
        public IActionResult CadastrarCliente([FromBody] ClienteEntity cliente)
        {
            return _cadastroController.CadastrarCliente(cliente);
        }

        /*
         * FITAS
         */

        [HttpGet("fitas")]
        public IActionResult PesquisarFitas([FromQuery] string busca)
        {
            return _fitaController.PesquisarFitas(busca);
        }
        
        [HttpPost("fitas/cadastrar")]
        public IActionResult CadastrarFita([FromBody] FitaEntity fita)
        {
            return _fitaController.CadastrarFita(fita);
        }

        /*
         * COMPRAS
         */

        [HttpPost("compras/realizar")]
        public IActionResult RealizarCompra([FromBody] CompraEntity compra)
        {
            return _compraController.RealizarCompra(compra);
        }

        [HttpPut("compras/{id}/avaliar")]
        public IActionResult AvaliarCompra(string id, [FromBody] AvaliacaoEntity avaliacao)
        {
            return _compraController.AvaliarCompra(id, avaliacao);
        }
    }
}
