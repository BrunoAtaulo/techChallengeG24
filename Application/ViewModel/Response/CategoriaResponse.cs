using Domain.Base;

namespace Application.ViewModel.Response
{
    public class CategoriaResponse
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public string NomeProduto { get; set; }
        public EnumCategoria NomeCategoria { get; set; }
    }
}
