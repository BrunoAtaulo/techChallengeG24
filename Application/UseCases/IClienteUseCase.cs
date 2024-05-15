using Domain.Entities;
using System.Collections.Generic;

namespace Application.UseCases
{
    public interface IClienteUseCase
    {
        IList<Cliente> GetCliente();

    }
}
