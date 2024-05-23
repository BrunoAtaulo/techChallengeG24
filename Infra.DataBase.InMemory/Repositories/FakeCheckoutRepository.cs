using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class FakeCheckoutRepository : IFakeCheckoutRepository
    {
        private readonly FiapDbContext _context;

        public FakeCheckoutRepository(FiapDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> FindProdutoByIdAsync(int idProduto)
        {
            return await _context.Produtos.FindAsync(idProduto);
        }

        public async Task AddFakeCheckoutAsync(FakeCheckout fakeCheckout)
        {
            _context.Checkout.Add(fakeCheckout);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FakeCheckout>> GetAllFakeCheckoutsAsync()
        {
            return await _context.Checkout
                .Include(fc => fc.Produto)
                .ToListAsync();
        }
    }
}
