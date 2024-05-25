using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pedido
    {
        public Pedido(int clienteId, DateTime dataPedido, int pedidoStatusId, int pedidoPagamentoId)
        {
            ClienteId = clienteId;
            DataPedido = dataPedido;
            PedidoStatusId = pedidoStatusId;
            PedidoPagamentoId = pedidoPagamentoId;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public int PedidoStatusId { get; set; }
        public int PedidoPagamentoId { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public List<Produto> Produtos { get; set; }

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
