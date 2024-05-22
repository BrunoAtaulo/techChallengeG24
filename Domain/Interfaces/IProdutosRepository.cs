using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProdutosRepository
    {
        Task<Produto> GetProdutoById(int id);
        Task<Produto> GetProdutoByIdCategoria(int idCategoria);
        Task PostProduto(Produto cliente);
        Task UpdateProduto(Produto cliente);

        Task DeleteProduto(Produto cliente);
    }
}
