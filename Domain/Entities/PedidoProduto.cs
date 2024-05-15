using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PedidoProduto
    {
        [Key]
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public Produto produto { get; set; }
        public Pedido Pedido { get; set; }
        public Combo? Combo { get; set; }

    }


}
