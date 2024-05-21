﻿using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(string cpfCliente);
        Task PostCliente(Cliente cliente);
    }
}
