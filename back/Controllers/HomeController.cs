using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Compras;
using Netfritz.Core.Repositories.Fitas;


namespace Netfritz.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {

        private Fachada _fachada;

        public HomeController(IUsuarioRepository usuarioRepository, IFitaRepository fitaRepository, ICompraRepository compraRepository)
        {
            _fachada = new Fachada(usuarioRepository, fitaRepository, compraRepository);
        }

        [HttpGet("pesquisar-fitas")]
        public IActionResult PesquisarFitas(string busca)
        {
            return _fachada.PesquisarFitas(busca);
        }
    }
}
