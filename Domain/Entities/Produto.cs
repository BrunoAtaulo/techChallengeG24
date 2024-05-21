using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Produto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]

        public virtual ProdutoCategoria Categoria { get; set; }

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
