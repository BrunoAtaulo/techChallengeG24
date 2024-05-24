using Domain.Entities.Validator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class PostProdutoRequest : IValidatableObject
    {
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }

        [CategoriaValid]
        public int IdCategoria { get; set; }

        public bool Ativo { get; set; } = true;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ValorProduto <= 0)
            {
                yield return new ValidationResult(
                    "O Valor do Produto deve ser maior que zero.",
                    new[] { nameof(ValorProduto) }
                );
            }

            if (string.IsNullOrWhiteSpace(NomeProduto))
            {
                yield return new ValidationResult(
                    "O Nome Produto nao deve ser estar vazio .",
                    new[] { nameof(NomeProduto) }
                );
            }
        }
    }
}
