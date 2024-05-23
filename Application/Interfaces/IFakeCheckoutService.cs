using Application.ViewModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFakeCheckoutService
    {
        Task<string> ProcessFakeCheckoutAsync(List<CheckoutRequest> produtos);
        Task<IEnumerable<object>> GetFakeCheckoutsAsync();
    }
}
