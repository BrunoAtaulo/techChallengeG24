using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pedido
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        public PedidoStatus PedidoStatus { get; set; }
        public PedidoPagamento PedidoPagamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public List<PedidoProduto> PedidoProdutos { get; set; }


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
