using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<IList<Cliente>> GetClientes();
    }
}
