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
        public DbSet<tabTipoProduto> tabTipoProduto { get; set; }
        public DbSet<tabProdutoDoado> tabProdutoDoado { get; set; }
        public DbSet<tabAprovacaoProduto> tabAprovacaoProduto { get; set; }

        public DbSet<tabDosagem> tabDosagem { get; set; }

        public DbSet<tabFormaMedicamento> tabFormaMedicamento { get; set; }

        public DbSet<tabStatus> tabStatus { get; set; }
        public DbSet<tabMensagens> tabMensagens { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("tabUsuario");
            modelBuilder.Entity<TabUnidade>().ToTable("tabUnidade");
            modelBuilder.Entity<TabTipoUsuario>().ToTable("tabTipoUsuario");
            modelBuilder.Entity<TabGenero>().ToTable("tabGenero");
            modelBuilder.Entity<tabTipoProduto>().ToTable("tabTipoProduto");
            modelBuilder.Entity<tabProdutoDoado>().ToTable("tabProdutoDoado");
            modelBuilder.Entity<tabAprovacaoProduto>().ToTable("tabAprovacaoProduto");
            modelBuilder.Entity<tabDosagem>().ToTable("tabDosagem");
            modelBuilder.Entity<tabFormaMedicamento>().ToTable("tabFormaMedicamento");
            modelBuilder.Entity<tabStatus>().ToTable("tabStatus");
            modelBuilder.Entity<tabMensagens>().ToTable("tabMensagens");
        }
    }
}
