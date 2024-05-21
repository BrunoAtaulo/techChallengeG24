using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class ComboRequest : IValidatableObject
    {
        public List<ProdutoPedidoRequest> ProdutoPedido { get; set; } = new List<ProdutoPedidoRequest>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (ProdutoPedido == null || ProdutoPedido.Count == 0)
            {
                yield return new ValidationResult(
                    "A lista de pedidos é obrigatória e deve ter pelo menos 1 item",
                    new[] { nameof(ProdutoPedido) }
                );

            }

        }
    }
}
