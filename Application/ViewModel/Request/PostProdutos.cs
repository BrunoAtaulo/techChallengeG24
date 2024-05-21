using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class PostProdutos : IValidatableObject
    {
  
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int IdCategoria { get; set; }
     
   

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
           
            if (string.IsNullOrWhiteSpace(NomeProduto))
            {
                yield return new ValidationResult("Nome do produto é obrigatório", new string[] { "NomeProduto" });
            }

            if (string.IsNullOrWhiteSpace(DescricaoProduto))
            {
                yield return new ValidationResult("Descricao do produto é obrigatório", new string[] { "DescricaoProduto" });
            }

            if (ValorProduto <= 0)
            {
                yield return new ValidationResult(
                    "O valor do produto é obrigatório.",
                     new string[] { "ValorProduto" }
                );
            }


            if (QuantidadeProduto <= 0)
            {
                yield return new ValidationResult(
                    "A quantidade do produto é obrigatória.",
                     new string[] { "QuantidadeProduto" }
                );
            }

            if (IdCategoria <= 0)
            {
                yield return new ValidationResult(
                    "O id da categoria é obrigatório.",
                    new[] { nameof(PedidoStatus) }
                );
            }

        }
    }
}
