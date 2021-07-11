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
        private readonly IUsuarioRepository _usuarioRepository;

        public CadastroController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Cliente

        public IActionResult ListarClientes()
        {
            try
            {
                var clientes = _usuarioRepository.GetClientes();

                return Response.CreateResponse(clientes, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível listar os clientes", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult ObterCliente(string id)
        {
            try
            {
                var cliente = _usuarioRepository.GetCliente(id);

                if (cliente is null)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                return Response.CreateResponse(cliente, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível obter o cliente", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult CadastrarCliente(ClienteEntity cliente)
        {
            try
            {
                if (CheckEmail(cliente.Email))
                {
                    return Response.CreateResponse("O email já está cadastrado", StatusCodes.Status409Conflict);
                }

                _usuarioRepository.InserirCliente(cliente);

                return Response.CreateResponse(cliente, StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível realizar o cadastro", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult AtualizarCliente(string id, ClienteEntity cliente)
        {
            try
            {
                var findCliente = _usuarioRepository.GetCliente(id);

                if (findCliente is null)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                _usuarioRepository.AtualizarCliente(findCliente);

                return Response.CreateResponse("Cliente atualizado com sucesso", StatusCodes.Status200OK);

            }
            catch (Exception)
            {

                return Response.CreateResponse("Não foi possível atualizar o cliente", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult RemoverCliente(string id)
        {
            try
            {
                var findCliente = _usuarioRepository.GetCliente(id);

                if (findCliente is null)
                {
                    return Response.CreateResponse("Cliente não encontrado", StatusCodes.Status404NotFound);
                }

                _usuarioRepository.RemoverCliente(id);

                return Response.CreateResponse("Cliente deletado com sucesso", StatusCodes.Status200OK);

            }
            catch (Exception)
            {

                return Response.CreateResponse("Não foi possível deletar o cliente", StatusCodes.Status500InternalServerError);
            }
        }

        // Administrador

        public IActionResult ObterAdministrador(string id)
        {
            try
            {
                var administrador = _usuarioRepository.GetAdministrador(id);

                if (administrador is null)
                {
                    return Response.CreateResponse("Administrador não encontrado", StatusCodes.Status404NotFound);
                }

                return Response.CreateResponse(administrador, StatusCodes.Status200OK);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível obter o administrador", StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult CadastrarAdministrador(AdministradorEntity administrador)
        {
            try
            {
                var checkEmail = CheckEmail(administrador.Email);

                if (checkEmail)
                {
                    return Response.CreateResponse("O email já está cadastrado", StatusCodes.Status409Conflict);
                }

                _usuarioRepository.InserirAdministrador(administrador);

                return Response.CreateResponse("Administrador criado com sucesso", StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return Response.CreateResponse("Não foi possível cadastrar o administrador", StatusCodes.Status201Created);

            }
        }

        public bool CheckEmail(string email)
        {
            return _usuarioRepository.GetClientes().Any(c => c.Email == email) || 
                _usuarioRepository.GetAdministradores().Any(a => a.Email == email);
        }

    }
}
