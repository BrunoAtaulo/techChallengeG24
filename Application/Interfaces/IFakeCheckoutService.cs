using Application.ViewModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFakeCheckoutService
    {
        Task<string> CadastroFakeCheckout(List<CheckoutRequest> produtos);
        Task<IEnumerable<object>> GetFakeCheckouts();
    }
}
