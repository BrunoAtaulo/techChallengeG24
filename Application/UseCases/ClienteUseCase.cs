using Domain.Entities;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.UseCases
{
    public class ClienteUseCase : IClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IList<Cliente> GetCliente()
        {
            return _clienteRepository.GetClientes();
        }
    }
}
