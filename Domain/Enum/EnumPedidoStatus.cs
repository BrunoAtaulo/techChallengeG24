using System.ComponentModel;

namespace Domain.Base
{
    public enum EnumPedidoStatus
    {
        [Description("1 - Recebido")]
        Recebido = 1,

        [Description("2 - Em Preparação")]
        EmPreparacao = 2,

        [Description("3 - Pronto")]
        Pronto = 3,

        [Description("4 - Finalizado")]
        Finalizado = 4
    }
}
