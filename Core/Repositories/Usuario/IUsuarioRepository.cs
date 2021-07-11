using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Core.Repositories
{
    public interface IUsuarioRepository
    {

        string? Login(string email, string senha);

        /*
         * Usuário: Cliente
         */

        List<ClienteEntity> GetClientes();

        ClienteEntity GetCliente(string id);

        void InserirCliente(ClienteEntity cliente);

        void AtualizarCliente(ClienteEntity cliente);

        void RemoverCliente(string id);

        /*
         * Usuário: Administrador
         */

        AdministradorEntity GetAdministrador(string id);

        void InserirAdministrador(AdministradorEntity administrador);

        void AtualizarAdministrador(AdministradorEntity administrador);

        public void RemoverAdministrador(string id);
    }
}
