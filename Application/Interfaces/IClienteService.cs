using Application.ViewModel.Request;
using Application.ViewModel.Response;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponse> GetClienteByCpf(ClienteByCpfRequest filtro);
        Task<ClienteByIdResponse> PostClientes(ClienteRequest filtro);

        Task UpdateClienteByCpf(ClienteByCpfRequest cpfCliente, PatchClienteRequest filtro);

        Task DeleteClienteByCpf(ClienteByCpfRequest cpfCliente);

    }
}
