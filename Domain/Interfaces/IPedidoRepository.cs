using Domain.Base;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces{
    public interface IPedidoRepository{
         Task PostPedido(Pedido pedido);

        Task<Pedido> GetPedidos(int id);
       

        Task<Pedido> GetPedidoByIdAsync(int idPedido);
        Task<bool> UpdatePedidoAsync(Pedido pedido);
    }
}