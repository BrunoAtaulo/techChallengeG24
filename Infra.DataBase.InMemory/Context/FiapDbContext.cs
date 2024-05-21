using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class FiapDbContext : DbContext
    {
        public FiapDbContext() { } // This one

        public FiapDbContext(DbContextOptions<FiapDbContext> options) : base(options)
        { }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<PedidoStatus> PedidoStatus { get; set; }

        public DbSet<PedidoProduto> PedidoProdutos { get; set; }

        public DbSet<PedidoPagamento> PedidosPagamentos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }

        public DbSet<Combo> Combos { get; set; }

        public DbSet<ComboProduto> ComboProdutos { get; set; }




        //  protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer("Server=localhost,1433;Database=FiapDB;User Id=SA;Password=Pa55w0rd2021;MultipleActiveResultSets=true");
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<string>()
                .HaveMaxLength(250);

            configurationBuilder.Properties<decimal>()
                 .HavePrecision(18, 2);

        }




    }






}


