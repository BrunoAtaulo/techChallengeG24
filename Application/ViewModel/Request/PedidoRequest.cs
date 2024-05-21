using Domain.Base;
using System;

namespace Application.ViewModel.Request
{
    public class PedidoRequest
    {
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public EnumPedidoStatus? PedidoStatus { get; set; }

        public EnumPedidoPagamento? PedidoPagamento { get; set; }

        public DateTime DataPedido { get; set; }



    }
}
