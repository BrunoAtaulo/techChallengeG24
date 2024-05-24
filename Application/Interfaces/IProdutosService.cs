using Application.ViewModel.Request;
using Application.ViewModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProdutosService
    {
        Task<ProdutoByIdRequest> PostProduto(PostProdutoRequest input);

        Task UpdateProdutoById(ProdutoByIdRequest produtoId, PatchProdutoRequest filtro);

        Task DeleteProdutoById(ProdutoByIdRequest produtoId);

        Task<IList<ProdutoResponse>> GetProdutoByCategoria(ProdutoByIdCategoriaRequest filtro);


    }
}
