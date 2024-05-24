using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFakeCheckoutRepository
    {
        Task<Produto> FindProdutoByIdAsync(int idProduto);
        Task AddFakeCheckoutAsync(FakeCheckout fakeCheckout);

        Task<List<FakeCheckout>> GetAllFakeCheckouts();
    }
}
