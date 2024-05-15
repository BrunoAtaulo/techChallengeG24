using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public Cliente? Cliente { get; set; }
        public PedidoStatus PedidoStatus { get; set; }
        public PedidoPagamento PedidoPagamento { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataCadastro { get; set; }
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
