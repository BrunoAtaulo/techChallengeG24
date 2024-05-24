using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class CheckoutRequest : IValidatableObject
    {

        public int IdProduto { get; set; }

        public int Quantidade { get; set; }

        public string NomeCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

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


        }


    }
}
