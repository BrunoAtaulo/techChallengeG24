using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.DataBase.InMemory.Repositories
{
    public class ClientesRepository : IClienteRepository
    {

        private readonly FiapDbContext _dbContext;

        public ClientesRepository(FiapDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<IList<Cliente>> GetClientes()
        {
            return await _dbContext.Clientes.Where(x => x.Id != 0).ToListAsync();
        }
    }
}
