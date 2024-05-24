using Application.ViewModel.Request;
using Application.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces{
    public interface IPedidoService{
        Task<PedidoByIdResponse> PostPedidos(PostPedidoRequest filtro);

        Task<IList<PedidoResponse>> GetPedidosAsync(PedidoRequest filtro);
    }
}