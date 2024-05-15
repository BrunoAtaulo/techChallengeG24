using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class Produto : IValidatableObject
    {
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           
            if (IdProduto <= 0)
            {
                yield return new ValidationResult(
                    "O id do produto é obrigatório e deve ser maior que zero.",
                    new[] { nameof(IdProduto) }
                );
            }

           
            if (QuantidadeProduto <= 0)
            {
                yield return new ValidationResult(
                    "A quantidade do produto é obrigatória e deve ser maior que zero.",
                    new[] { nameof(QuantidadeProduto) }
                );
            }
        }
    }
}
