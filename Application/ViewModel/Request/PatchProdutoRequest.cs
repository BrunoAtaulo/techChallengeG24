namespace Application.ViewModel.Request
{
    public class PatchProdutoRequest
    {

        public string NomeProduto { get; set; }
        public decimal? ValorProduto { get; set; }
        public int? IdCategoria { get; set; }

        public bool? Ativo { get; set; }



    }
}
