using Domain.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class PedidoRequest
    {
        [FromRoute(Name = "idPedido")]
        public int IdPedido { get; set; }
        public EnumPedidoStatus? PedidoStatus { get; set; }
        public EnumPedidoPagamento? PedidoPagamento { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (IdPedido <= 0)
                yield return new ValidationResult("idPedido é obrigatório", new string[] { "idPedido" });


        }


    }
}
