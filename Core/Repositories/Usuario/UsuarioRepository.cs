using Microsoft.EntityFrameworkCore;
using Netfritz.Context;
using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Netfritz.Core.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        /*
         * Login
         */

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(c => c.Email == email && c.Senha == senha);
        }

        /*
         * Cliente
         */

        public List<ClienteEntity> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public ClienteEntity GetCliente(string id)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public void InserirCliente(ClienteEntity cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void AtualizarCliente(ClienteEntity cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void RemoverCliente(string id)
        {
            var cliente = _context.Clientes
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        /*
         * Administrador
         */

        public List<AdministradorEntity> GetAdministradores()
        {
            return _context.Administradores.ToList();
        }

        public AdministradorEntity GetAdministrador(string id)
        {
            return _context.Administradores.FirstOrDefault(a => a.Id == id);
        }

        public void InserirAdministrador(AdministradorEntity administrador)
        {
            _context.Administradores.Add(administrador);
            _context.SaveChanges();
        }

        public void AtualizarAdministrador(AdministradorEntity administrador)
        {
            _context.Administradores.Update(administrador);
            _context.SaveChanges();
        }

        public void RemoverAdministrador(string id)
        {
            var administrador = _context.Administradores
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == id);

            _context.Administradores.Remove(administrador);
            _context.SaveChanges();
        }

    }
}
