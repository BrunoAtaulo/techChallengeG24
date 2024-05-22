using Application.ViewModel.Request;
using Application.ViewModel.Response;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutosService
    {
        Task<ProdutoByIdResponse> PostProduto(ProdutoRequest filtro);

        Task UpdateProdutoById(ProdutoByIdRequest produtoId, PatchProdutoRequest filtro);

        Task DeleteClienteByCpf(ProdutoByIdRequest produtoId);


        Task<ProdutoResponse> GetProdutoByCategoria(ProdutoByIdCategoriaRequest filtro);




    }
}
