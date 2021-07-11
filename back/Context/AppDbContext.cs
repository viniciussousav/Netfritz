using Microsoft.EntityFrameworkCore;
using Netfritz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netfritz.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ClienteEntity> Clientes { get; set; }

        public DbSet<AdministradorEntity> Administradores { get; set; }

        public DbSet <FitaEntity> Fitas { get; set; }

        public DbSet<CompraEntity> Compras { get; set; }

    }
}
