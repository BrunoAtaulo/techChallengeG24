using Domain.Base;
using System;

namespace Application.ViewModel.Response
{
    public class PedidoResponse
    {
        public int IdCliente { get; set; }

        public int IdPedido { get; set; }

        public int QuatidadePedido { get; set; }

        public int? IdCombo { get; set; }

        public EnumPedidoStatus? PedidoStatus { get; set; }

        public EnumPedidoPagamento? PedidoPagamento { get; set; }

        public DateTime DataPedido { get; set; }


    }
}
