using Domain.Base;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPedidoRepository
    {
        
        Task<IList<Pedido>> GetPedidosAsync(int? idPedido, EnumPedidoStatus? pedidoStatus, EnumPedidoPagamento? pedidoPagamento);

        Task<bool> UpdatePedidoAsync(Pedido pedido);
        Task<Pedido> GetPedidosByIdAsync(int idPedido);
    }
}