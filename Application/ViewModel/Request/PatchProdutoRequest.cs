namespace Application.ViewModel.Request
{
    public class PatchProdutoRequest
    {

        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int IdCategoria { get; set; }


    }
}
