using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infra.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly FiapDbContext _context;

        public PedidoRepository(FiapDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Pedido>> GetPedidosAsync(int? idPedido, EnumPedidoStatus? pedidoStatus, EnumPedidoPagamento? pedidoPagamento)
        {
            var query = _context.Pedidos.AsQueryable();

            if(idPedido.HasValue)
                query = query.Where(p => p.Id == idPedido);

            if (pedidoStatus.HasValue)
                query = query.Where(p => p.PedidoStatusId == (int)pedidoStatus.Value);
            
            if (pedidoPagamento.HasValue)
                query = query.Where(p => p.PedidoPagamentoId == (int)pedidoPagamento.Value);
            
            return await query.ToListAsync();
        }

        public async Task<Pedido> GetPedidosByIdAsync(int idPedido)
        {
            var query = _context.Pedidos.AsQueryable();

                query = query.Where(p => p.Id == idPedido);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> UpdatePedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            return await _context.SaveChangesAsync() > 0;
        }


    }

}