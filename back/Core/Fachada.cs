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
using Microsoft.AspNetCore.Http;

namespace Netfritz.Controllers
{
    
    public class Fachada 
    {

        private readonly AuthControlador _authControlador;
        private readonly CadastroControlador _cadastroControlador;
        private readonly FitaControlador _fitaControlador;
        private readonly CompraControlador _compraControlador;
        private readonly S3StorageControlador _s3StorageControlador;
        
        public Fachada(IUsuarioRepository usuarioRepository, IFitaRepository fitaRepository, ICompraRepository compraRepository)
        {
            _authControlador = new AuthControlador(usuarioRepository);
            _cadastroControlador = new CadastroControlador(usuarioRepository);
            _fitaControlador = new FitaControlador(fitaRepository, usuarioRepository);
            _compraControlador = new CompraControlador(compraRepository, usuarioRepository);
            _s3StorageControlador = new S3StorageControlador(fitaRepository);
        }

        // Login

        public IActionResult Login(Login login)
        {
            return _authControlador.Login(login.Email, login.Senha);
        }

        // Cliente
    
        public IActionResult ObterCliente(string id)
        {
            return _cadastroControlador.ObterCliente(id);
        }

        public IActionResult CadastrarCliente(ClienteEntity cliente)
        {
            return _cadastroControlador.CadastrarCliente(cliente);
        }

        public IActionResult AtualizarCliente(string id, ClienteEntity cliente)
        {
            return _cadastroControlador.AtualizarCliente(id, cliente);
        }

        public IActionResult RemoverCliente(string id)
        {
            return _cadastroControlador.RemoverCliente(id);
        }

        public IActionResult ListarCompras(string id)
        {
            return _compraControlador.ListarComprasCliente(id);
        }

        public IActionResult RealizarCompra(string id, string fitaId)
        {
            return _compraControlador.RealizarCompra(id, fitaId);
        }

        public IActionResult AvaliarCompra(string id, string compraId, AvaliacaoEntity avaliacao)
        {
            return _compraControlador.AvaliarCompra(id, compraId, avaliacao);
        }

        // Administrador 

        public IActionResult ObterAdministrador(string id)
        {
            return _cadastroControlador.ObterAdministrador(id);
        }
        
        public IActionResult CadastrarAdministrador(AdministradorEntity administrador)
        {
            return _cadastroControlador.CadastrarAdministrador(administrador);
        }

        public IActionResult VisualizarVendas()
        {
            return _compraControlador.ListarCompras();
        }

        public IActionResult CadastrarFita(FitaEntity fita)
        {
            return _fitaControlador.CadastrarFita(fita);
        }

        public IActionResult AtualizarFita(string fitaId, FitaEntity fita)
        {
            return _fitaControlador.AtualizarFita(fitaId, fita);
        }

        public IActionResult RemoverFita( string fitaId)
        {
            return _fitaControlador.RemoverFita(fitaId);
        }

        // Fitas

        [HttpGet("fitas")]
        public IActionResult PesquisarFitas(string busca)
        {
            return _fitaControlador.PesquisarFitas(busca);
        }
        
        [HttpGet("fitas/{id}")]
        public IActionResult PesquisarFita(string id)
        {
            return _fitaControlador.ObterFita(id);
        }

        [HttpPut("fitas/{id}/upload-imagem")]
        public async Task<IActionResult> UploadImageFita(string id, IFormFile imagem)
        {
            return await _s3StorageControlador.UploadImagem(id, imagem);
        }
    }
}
