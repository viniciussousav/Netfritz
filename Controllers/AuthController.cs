using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Controllers
{
    public class AuthController
    {
        private readonly IUsuarioRepository _clienteRepository;

        public AuthController(IUsuarioRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Login(string email, string senha)
        {
            try
            {
                var login = _clienteRepository.Login(email, senha);

                if (string.IsNullOrEmpty(login))
                {
                    return Response.CreateResponse("Email ou senha errados", StatusCodes.Status401Unauthorized);
                }

                return Response.CreateResponse(login, StatusCodes.Status202Accepted);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro interno, tente novamente", StatusCodes.Status500InternalServerError);
            }
        }

    }
}
