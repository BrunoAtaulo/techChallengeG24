using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
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

    public async Task<IList<Pedido>> GetPedidosAsync(int? idCliente, int? idPedido, EnumPedidoStatus? pedidoStatus, EnumPedidoPagamento? pedidoPagamento, DateTime? dataPedido)
    {
        var query = _context.Pedidos.AsQueryable();

        if (idCliente.HasValue)
        {
            query = query.Where(p => p.ClienteId == idCliente.Value);
        }

        if (idPedido.HasValue)
        {
            query = query.Where(p => p.Id == idPedido.Value);
        }

        if (pedidoStatus.HasValue)
        {
            query = query.Where(p => p.PedidoStatusId == (int)pedidoStatus.Value);
        }

        if (pedidoPagamento.HasValue)
        {
            query = query.Where(p => p.PedidoPagamentoId == (int)pedidoPagamento.Value);
        }

        if (dataPedido.HasValue)
        {
            query = query.Where(p => p.DataPedido.Date == dataPedido.Value.Date);
        }

        return await query.ToListAsync();
    }

}