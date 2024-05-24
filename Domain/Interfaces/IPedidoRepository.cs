using Domain.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces{
    public interface IPedidoRepository{
         Task PostPedido(Pedido pedido);
        Task<IList<Pedido>> GetPedidosAsync(int? idCliente, int? idPedido, EnumPedidoStatus? pedidoStatus, EnumPedidoPagamento? pedidoPagamento, DateTime? dataPedido);
    }
}