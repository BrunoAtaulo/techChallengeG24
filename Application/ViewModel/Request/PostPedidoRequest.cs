using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class PostPedidoRequest : IValidatableObject
    {
        public int IdCliente { get; set; }

        public string DataPedido { get; set; }

        public EnumPedidoStatus? PedidoStatus { get; set; }

        public EnumPedidoPagamento? PedidoPagamento { get; set; }

        //public List<ComboRequest> ComboPedido { get; set; }

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

            if (!PedidoPagamento.HasValue)
            {
                yield return new ValidationResult(
                    "O status do pagamento é obrigatório.",
                    new[] { nameof(PedidoPagamento) }
                );
            }

            if (string.IsNullOrEmpty(DataPedido))
            {
                yield return new ValidationResult(
                    "A data do pedido é obrigatória.",
                    new[] { nameof(DataPedido) }
                );
            }
            else if (!DateTime.TryParseExact(DataPedido, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                yield return new ValidationResult(
                    "A data do pedido deve estar no formato dd/MM/yyyy.",
                    new[] { nameof(DataPedido) }
                );
            }


            // if (ComboPedido == null || ComboPedido.Count == 0)
            // {
            //     yield return new ValidationResult(
            //         "A lista de combo é obrigatória e deve ter pelo menos 1 item",
            //         new[] { nameof(ComboPedido) }
            //     );

            // }
        }


    }
}
