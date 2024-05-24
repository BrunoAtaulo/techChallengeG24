using Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Produto
    {
        public Produto(int categoriaId, string nome, decimal preco, bool status)
        {

            CategoriaId = categoriaId;

            Nome = nome;
            Preco = preco;
            Status = status;
            ValidateEntity();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public bool Status { get; set; }


        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "O nome não pode estar vazio!");

            AssertionConcern.AssertArgumentNotNull(Preco, "O Preco não pode estar vazio!");

            AssertionConcern.AssertArgumentNotNull(CategoriaId, "A Categoria não pode estar vazio!");


        }
    }


}
