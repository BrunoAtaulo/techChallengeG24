using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class PedidoIdRequest: IValidatableObject
    {
        public int idPedido { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (idPedido <= 0)
                yield return new ValidationResult("Id do IdPedido é obrigatório", new string[] { "IdPedido" });
        }
    }
}
