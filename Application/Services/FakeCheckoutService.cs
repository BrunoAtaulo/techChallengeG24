using Application.Interfaces;
using Application.ViewModel.Request;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FakeCheckoutService : IFakeCheckoutService
    {
        private readonly IFakeCheckoutRepository _repository;

        public FakeCheckoutService(IFakeCheckoutRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> CadastroFakeCheckout(List<CheckoutRequest> produtos)
        {
            if (produtos == null || produtos.Count == 0)
            {
                return "A lista de produtos não pode ser nula ou vazia.";
            }

            foreach (var item in produtos)
            {
                var produto = await _repository.FindProdutoByIdAsync(item.IdProduto);
                if (produto == null)
                {
                    return $"Produto com Id {item.IdProduto} não encontrado.";
                }

                var fakeCheckout = new FakeCheckout
                {
                    Produto = produto,
                    Quantidade = item.Quantidade,
                    NomeCliente = item.NomeCliente
                };

                await _repository.AddFakeCheckoutAsync(fakeCheckout);
            }

            return "Produtos enviados para a fila com sucesso!";
        }

        public async Task<IEnumerable<object>> GetFakeCheckouts()
        {
            var filaDePedidos = await _repository.GetAllFakeCheckouts();

            return filaDePedidos.Select(item => new
            {
                id = item.Id,
                produto = new
                {
                    id = item.Produto.Id,
                    categoriaId = item.Produto.CategoriaId,
                    categoria = ((EnumCategoria)item.Produto.CategoriaId).ToString(),
                    nome = item.Produto.Nome,
                    preco = item.Produto.Preco
                },
                quantidade = item.Quantidade,
                nomeCliente = item.NomeCliente,
                valorTotal = item.Quantidade * item.Produto.Preco
            });
        }
    }
}
