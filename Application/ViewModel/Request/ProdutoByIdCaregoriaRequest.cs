using Domain.Entities.Validator;

namespace Application.ViewModel.Request
{
    public class ProdutoByIdCategoriaRequest
    {
        [CategoriaValid]
        public int IdCategoria { get; set; }



    }
}
