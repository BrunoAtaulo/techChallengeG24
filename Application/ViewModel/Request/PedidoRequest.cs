using Domain.Base;

namespace Application.ViewModel.Request
{
    public class PedidoRequest
    {
        public int? IdPedido { get; set; }
        public EnumPedidoStatus? PedidoStatus { get; set; }
        public EnumPedidoPagamento? PedidoPagamento { get; set; }

        
    }
}
