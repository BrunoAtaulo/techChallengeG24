using Domain.Base;
using System;

namespace Domain.Entities.Input
{
    public class Pedidos 
    {
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public EnumPedidoStatus? PedidoStatus { get; set; }

        public EnumPedidoPagamento? PedidoPagamento { get; set; }

        public DateTime DataPedido { get; set; }

        

    }
}
