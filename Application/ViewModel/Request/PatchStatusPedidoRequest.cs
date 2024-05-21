using Domain.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class PatchStatusPedidoRequest : IValidatableObject
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
