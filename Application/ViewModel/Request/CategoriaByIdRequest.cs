using Domain.Entities.Validator;

namespace Application.ViewModel.Request
{
    public class CategoriaByIdRequest
    {
        [CategoriaValid]
        public int IdCategoria { get; set; }

    }
}
