using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class Combo : IValidatableObject
    {
        public List<ProdutoPedido> ProdutoPedido { get; set; } = new List<ProdutoPedido>();

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
