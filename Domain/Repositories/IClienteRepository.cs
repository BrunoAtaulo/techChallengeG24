using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IClienteRepository
    {
        IList<Cliente> GetClientes();
    }
}
