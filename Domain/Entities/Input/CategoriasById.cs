using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class CategoriasById : IValidatableObject
    { 
        public int IdCategoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IdCategoria <= 0)
                yield return new ValidationResult("Id da categoria � obrigat�rio", new string[] { "IdCategoria" });
        }
    }
}