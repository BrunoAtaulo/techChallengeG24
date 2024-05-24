using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.DataBase.InMemory.Repositories
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly FiapDbContext _dbContext;

        public ProdutosRepository(FiapDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostProduto(Produto Produto)
        {
            await _dbContext.Produtos.AddAsync(Produto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IList<Produto>> GetProdutosByIdCategoria(int idCategoria)
        {
            return await _dbContext.Produtos.Where(c => c.CategoriaId == idCategoria).ToListAsync();
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
