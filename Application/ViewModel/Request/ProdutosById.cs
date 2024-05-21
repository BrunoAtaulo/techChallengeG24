using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class ProdutosById : IValidatableObject
    {
        public int IdProduto { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IdProduto <= 0)
                yield return new ValidationResult("Id do produto é obrigatório", new string[] { "IdProduto" });
        }

    }
}
