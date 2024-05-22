using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class FakeCheckout
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("PedidoId")]
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }
      
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string NomeCliente { get; set; }
       


        #region Validations
        //public void Validate()
        //{
        //    ValidaNome();
        //}

        //private void ValidaNome()
        //{
        //    if (string.IsNullOrWhiteSpace(Nome))
        //        throw new Exception("por favor, informe o nome.");

        //}
        #endregion
    }


}
