using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class Checkouts : IValidatableObject
    {
        public int IdPedido { get; set; }
        public string NomeProduto { get; set; }

        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public string NomeCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IdPedido <= 0)
            {
                yield return new ValidationResult(
                    "O Id do pedido é obrigatório.",
                    new[] { nameof(IdPedido) }
                );
            }


            if (string.IsNullOrWhiteSpace(NomeProduto))
            {
                yield return new ValidationResult("Nome do produto é obrigatório", new string[] { "NomeProduto" });
            }

            if (Quantidade <= 0)
            {
                yield return new ValidationResult(
                    "A quantidade do pedido é obrigatória.",
                    new[] { nameof(Quantidade) }
                );
            }

            if (ValorUnitario <= 0)
            {
                yield return new ValidationResult(
                    "O valor unitário do produto é obrigatório.",
                      new[] { nameof(ValorUnitario) }
                );
            }


        }


    }
}
