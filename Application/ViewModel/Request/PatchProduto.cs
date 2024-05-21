using Domain.Base;

namespace Domain.Entities.Input
{
    public class PatchProduto
    {
  
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int IdCategoria { get; set; }
     

    }
}
