using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Entities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteByIdResponse> PostClientes(ClienteRequest filtro)
        {
            var rtn = new Cliente(
                filtro.CpfCliente,
                filtro.NomeCliente,
                filtro.SobrenomeCliente,
                filtro.EmailCliente,
                filtro.NomeSocialCliente               
            );

            await _clienteRepository.PostCliente(rtn);

            return new ClienteByIdResponse
            {
                IdCliente = rtn.Id
            };
        }

        public async Task<ClienteResponse> GetClienteByCpf(ClienteByCpfRequest filtro)
        {
            var cliente = await _clienteRepository.GetCliente(filtro.CpfCliente);
            if (cliente == null) return null;

            return new ClienteResponse
            {
                IdCliente = cliente.Id,
                CpfCliente = cliente.Cpf,
                NomeCliente = cliente.Nome,
                SobreNomeCliente = cliente.SobreNome,
                EmailCliente = cliente.Email,
                NomeSocialCliente = cliente.NomeSocial,
                DataCadastroCliente = cliente.DataCadastro
            };
        }


    }
}