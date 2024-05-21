using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class ProdutoRequest : IValidatableObject
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
