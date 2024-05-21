﻿using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientesService
    {
      Task<IList<Cliente>> GetCliente();

    }
}
