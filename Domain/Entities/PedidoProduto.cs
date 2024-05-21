using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class PedidoProduto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]

        public virtual Produto Produto { get; set; }

        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        public int? ComboId { get; set; }

        [ForeignKey("ComboId")]

        public virtual Combo? Combo { get; set; }

    }


}
