using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class PostProdutos : IValidatableObject
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string ImagemProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categorias Categoria { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IdProduto <= 0)
            {
                yield return new ValidationResult(
                    "O id do produto é obrigatório e deve ser maior que zero.",
                    new[] { nameof(IdProduto) }
                );
            }

            if (string.IsNullOrWhiteSpace(NomeProduto))
            {
                yield return new ValidationResult("Nome do produto é obrigatório", new string[] { "NomeProduto" });
            }

            if (string.IsNullOrWhiteSpace(DescricaoProduto))
            {
                yield return new ValidationResult("Descricao do produto é obrigatório", new string[] { "DescricaoProduto" });
            }

            if (string.IsNullOrWhiteSpace(ImagemProduto))
            {
                yield return new ValidationResult("Imagem do produto é obrigatório", new string[] { "ImagemProduto" });
            }
        }
    }
}
