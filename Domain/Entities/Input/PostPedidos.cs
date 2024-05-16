using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class PostPedidos : IValidatableObject
    {
        public int IdCliente { get; set; }

        public DateTime DataPedido { get; set; }

        public EnumPedidoStatus? PedidoStatus { get; set; }

        public List<Combo> ComboPedido { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IdCliente <= 0)
            {
                yield return new ValidationResult(
                    "O Id do cliente é obrigatório.",
                    new[] { nameof(IdCliente) }
                );
            }

          
            if (!PedidoStatus.HasValue)
            {
                yield return new ValidationResult(
                    "O status do pedido é obrigatório.",
                    new[] { nameof(PedidoStatus) }
                );
            }

           
            if (DataPedido == default)
            {
                yield return new ValidationResult(
                    "A data do pedido é obrigatória.",
                    new[] { nameof(DataPedido) }
                );
            }


            if (ComboPedido == null || ComboPedido.Count == 0)
            {
                yield return new ValidationResult(
                    "A lista de combo é obrigatória e deve ter pelo menos 1 item",
                    new[] { nameof(ComboPedido) }
                );

            }
        }


    }
}
