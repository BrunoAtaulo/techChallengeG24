using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClientesService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IList<Cliente>> GetCliente()
        {
         
            return await _clienteRepository.GetClientes();
        }
    }
}
