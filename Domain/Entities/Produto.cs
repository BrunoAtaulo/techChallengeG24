using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public ProdutoCategoria Categoria { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public bool Status { get; set; }


        #region Validations
        public void Validate()
        {
            ValidaNome();
            ValidaPreco();
        }

        private void ValidaNome()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("por favor, informe o nome.");

        }
        private void ValidaPreco()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("por favor, informe um preço.");

        }
        #endregion
    }


}
