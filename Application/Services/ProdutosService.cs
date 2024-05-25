using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _repository;

        public ProdutosService(IProdutosRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProdutoByIdRequest> PostProduto(PostProdutoRequest input)
        {
            var item = new Produto(input.IdCategoria, input.NomeProduto, input.ValorProduto, input.Ativo);

            await _repository.PostProduto(item);

            return new ProdutoByIdRequest
            {
                idProduto = item.Id
            };
        }

        public async Task UpdateProdutoById(ProdutoByIdRequest produtoId, PatchProdutoRequest input)
        {
            Produto itemProduto = await ValidProduto(produtoId);

            itemProduto.Status = input.Ativo ?? itemProduto.Status;
            itemProduto.Preco = input.ValorProduto ?? itemProduto.Preco;
            itemProduto.Nome = !string.IsNullOrEmpty(input.NomeProduto) ? input.NomeProduto : itemProduto.Nome;
            await _repository.UpdateProduto(itemProduto);

        }


        public async Task DeleteProdutoById(ProdutoByIdRequest produtoId)
        {
            Produto itemProduto = await ValidProduto(produtoId);

            await _repository.DeleteProduto(itemProduto);
        }
        public async Task<IList<ProdutoResponse>> GetProdutoByCategoria(ProdutoByIdCategoriaRequest filtro)
        {

            var lstProduto = await _repository.GetProdutosByIdCategoria(filtro.IdCategoria);
            if (lstProduto is null)
                return default;



            return lstProduto.Select(s => new ProdutoResponse(s)).ToList();
        }

        #region Uteis
        private async Task<Produto> ValidProduto(ProdutoByIdRequest produtoId)
        {
            var itemProduto = await _repository.GetProdutoById(produtoId.idProduto);
            if (itemProduto is null)
                throw new CustomValidationException("Produto não encontrado");
            return itemProduto;
        }


        #endregion

    }
}