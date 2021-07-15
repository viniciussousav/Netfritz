using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Models.BaseClass;
using Netfritz.Core.Repositories;
using Netfritz.Core.Repositories.Compras;
using Netfritz.Core.Repositories.Fitas;

namespace Netfritz.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private Fachada _fachada;

        public LoginController(IUsuarioRepository usuarioRepository, IFitaRepository fitaRepository, ICompraRepository compraRepository)
        {
            _fachada = new Fachada(usuarioRepository, fitaRepository, compraRepository);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login login)
        {
            return _fachada.Login(login);
        }
    }
}
