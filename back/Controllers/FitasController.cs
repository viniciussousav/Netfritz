using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Compras;
using Netfritz.Core.Repositories.Fitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Controllers
{
    [Route("api")]
    [ApiController]
    public class FitaController
    {
        private Fachada _fachada;

        public FitaController(IUsuarioRepository usuarioRepository, IFitaRepository fitaRepository, ICompraRepository compraRepository)
        {
            _fachada = new Fachada(usuarioRepository, fitaRepository, compraRepository);
        }

        [HttpPost("fitas/cadastrar-fita")]
        public IActionResult CadastrarFita([FromBody] FitaEntity fita)
        {
            return _fachada.CadastrarFita(fita);
        }

        [HttpPut("fitas/upload-imagem/{fitaId}")]
        public async Task<IActionResult> UploadImageFita(string fitaId, [FromForm] IFormFile imagem)
        {
            return await _fachada.UploadImageFita(fitaId, imagem);
        }

        [HttpPut("fitas/atualizar-fita/{fitaId}")]
        public IActionResult AtualizarFita(string fitaId, [FromBody] FitaEntity fita)
        {
            return _fachada.AtualizarFita(fitaId, fita);
        }

        [HttpDelete("fitas/remover-fita/{fitaId}")]
        public IActionResult RemoverFita(string fitaId)
        {
            return _fachada.RemoverFita(fitaId);
        }
    }
}
