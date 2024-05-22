using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<ProdutoByIdRequest> PostProduto(ProdutoRequest input)
        {
            var item = new Produto(input.IdCategoria,input.NomeProduto ,input.ValorProduto, input.Ativo);

            await _repository.PostProduto(item);

            return new ProdutoByIdRequest
            {
                IdProduto = item.Id
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

        
        public async Task DeleteClienteByCpf(ProdutoByIdRequest produtoId)
        {
            Produto itemProduto = await ValidProduto(produtoId);

            await _repository.DeleteProduto(itemProduto);
        }
        public async Task<ProdutoResponse> GetProdutoByCategoria(ProdutoByIdCategoriaRequest filtro)
        {

            var itemProduto = await _repository.GetProdutoByIdCategoria(filtro.IdCategoria);
            if (itemProduto is null)
                 return default;
            return new ProdutoResponse(itemProduto);
        }

        #region Uteis
        private async Task<Produto> ValidProduto(ProdutoByIdRequest produtoId)
        {
            var itemProduto = await _repository.GetProdutoById(produtoId.IdProduto);
            if (itemProduto is null)
                throw new CustomValidationException("Produto não encontrado");
            return itemProduto;
        }
        #endregion

    }
}