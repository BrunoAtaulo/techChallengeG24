using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class CheckoutRequest : IValidatableObject
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }

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


            if (IdProduto <= 0)
            {
                yield return new ValidationResult(
                    "O Id do produto é obrigatório.",
                    new[] { nameof(IdProduto) }
                );
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
