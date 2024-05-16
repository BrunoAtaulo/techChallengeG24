using Domain.Base;

namespace Domain.Entities.Input
{
    public class PatchProdutos 
    {
  
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int IdCategoria { get; set; }
     

    }
}
