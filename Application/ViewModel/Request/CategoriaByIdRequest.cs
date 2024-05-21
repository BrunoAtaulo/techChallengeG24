using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class CategoriaByIdRequest : IValidatableObject
    { 
        public int IdCategoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IdCategoria <= 0)
                yield return new ValidationResult("Id da categoria é obrigatório", new string[] { "IdCategoria" });
        }
    }
}
