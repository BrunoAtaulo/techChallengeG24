using Domain.Entities.Validator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class CategoriaByIdRequest 
    {
        [CategoriaValid]
        public int IdCategoria { get; set; }

    }
}
