﻿using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
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


        public async Task PostCliente(Cliente cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cliente>GetCliente(string cpfCliente)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpfCliente);
        }
    }
}