using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<TabUsuario> tabUsuario { get; set; }
        public DbSet<TabUnidade> tabUnidade { get; set; }
        public DbSet<TabTipoUsuario> tabTipoUsuario { get; set; }
        public DbSet<TabGenero> tabGenero { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("tabUsuario");
            modelBuilder.Entity<TabUnidade>().ToTable("tabUnidade");
            modelBuilder.Entity<TabTipoUsuario>().ToTable("tabTipoUsuario");
            modelBuilder.Entity<TabGenero>().ToTable("tabGenero");



        }
    }
}
