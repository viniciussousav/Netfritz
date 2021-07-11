using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Netfritz.Context;
using Netfritz.Core.Entities;
using Netfritz.Core.Repositories;
using System;
using System.Linq;

namespace Netfritz.Controllers
{
    public class CadastroController
    {
        private readonly IUsuarioRepository _clienteRepository;

        public CadastroController(IUsuarioRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult CadastrarCliente(ClienteEntity cliente)
        {
            try
            {
                if (CheckClienteEmail(cliente.Email))
                {
                    return Response.CreateResponse("O email já está em uso", StatusCodes.Status409Conflict);
                }

                _clienteRepository.InserirCliente(cliente);

                return Response.CreateResponse("Cliente inserido com sucesso", StatusCodes.Status202Accepted);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Erro interno, tente novamente", StatusCodes.Status500InternalServerError);
            }
        }

        public bool CheckClienteEmail(string email)
        {
            return _clienteRepository.GetClientes().Any(c => c.Email == email);
        }

    }
}
