using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPedidoService
    {

        Task<IList<PedidoResponse>> GetPedidosAsync(PedidoRequest filtro);

        Task<bool> UpdatePedidoStatusAsync(PedidoIdRequest input);
    }
}