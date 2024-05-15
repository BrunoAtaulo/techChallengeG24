using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class PatchStatusPedido : IValidatableObject
    {

        public EnumPedidoStatus? PedidoStatus { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (!PedidoStatus.HasValue)
            {
                yield return new ValidationResult(
                    "O status do pedido é obrigatório.",
                    new[] { nameof(PedidoStatus) }
                );
            }

        }


    }
}
