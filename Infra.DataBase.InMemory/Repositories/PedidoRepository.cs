using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
public class PedidoRepository : IPedidoRepository
{
    private readonly FiapDbContext _context;

    public PedidoRepository(FiapDbContext context)
    {
        _context = context;
    }

    public async Task PostPedido(Pedido pedido)
    {
          await _context.Pedidos.AddAsync(pedido);
          await _context.SaveChangesAsync();
    }
}