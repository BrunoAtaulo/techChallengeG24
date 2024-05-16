using System.ComponentModel;

namespace Domain.Base
{
    public enum EnumCategoria
    {
        [Description("1 - Lanche")]
        Lanche = 1,

        [Description("2 - Acompanhamento")]
        Acompanhamento = 2,

        [Description("3 - Bebida")]
        Bebida = 3,

        [Description("4 - Sobremesa")]
        Sobremesa = 4
    }
}
