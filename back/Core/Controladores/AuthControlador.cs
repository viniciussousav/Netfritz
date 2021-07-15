using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Controllers
{
    public class AuthControlador
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthControlador(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Login(string email, string senha)
        {
            try
            {
                var user = _usuarioRepository.Login(email, senha);

                if (user is null)
                {
                    return Response.CreateResponse("Usuário não encontrado", StatusCodes.Status404NotFound);
                }

                return user is ClienteEntity cliente
                    ? Response.CreateResponse(cliente, StatusCodes.Status202Accepted)
                    : Response.CreateResponse((AdministradorEntity)user, StatusCodes.Status202Accepted);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro interno, tente novamente", StatusCodes.Status500InternalServerError);
            }
        }

    }
}
