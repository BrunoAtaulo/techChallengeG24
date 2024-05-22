using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.DataBase.InMemory.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly FiapDbContext _dbContext;
        public async Task PostProduto(Produto Produto)
        {
            await _dbContext.Produtos.AddAsync(Produto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Produto> GetProdutoByIdCategoria(int idCategoria)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(c => c.CategoriaId == idCategoria);
        }
        public async Task<Produto> GetProdutoById(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateProduto(Produto Produto)
        {
            _dbContext.Produtos.Update(Produto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduto(Produto Produto)
        {
            _dbContext.Produtos.Remove(Produto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
