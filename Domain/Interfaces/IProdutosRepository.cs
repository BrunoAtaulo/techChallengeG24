using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProdutosRepository
    {
        Task<Produto> GetProdutoById(int id);
        Task<IList<Produto>> GetProdutosByIdCategoria(int idCategoria);
        Task PostProduto(Produto cliente);
        Task UpdateProduto(Produto cliente);

        Task DeleteProduto(Produto cliente);
    }
}
