using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.Entities.Input
{
    public class Produtos : IValidatableObject
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int IdCategoria { get; set; }
        public EnumCategoria NomeCategoria { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IdProduto <= 0)
            {
                yield return new ValidationResult(
                    "O id do produto deve ser maior que zero.",
                    new[] { nameof(IdProduto) }
                );
            }
        }
    }
}
