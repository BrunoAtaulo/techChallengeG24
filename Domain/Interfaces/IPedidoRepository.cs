using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces{
    public interface IPedidoRepository{
         Task PostPedido(Pedido pedido);
    }
}