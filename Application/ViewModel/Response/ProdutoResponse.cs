using Domain.Base;
using Domain.Entities;
using System;

namespace Application.ViewModel.Response
{
    public class ProdutoResponse
    {
        public ProdutoResponse(Produto _produto)
        {

            IdProduto = _produto.Id;
            NomeProduto = _produto.Nome;
            ValorProduto = _produto.Preco;
            Ativo = _produto.Status;
            IdCategoria = _produto.CategoriaId;
            NomeCategoria = (EnumCategoria)Enum.Parse(typeof(EnumCategoria), IdCategoria.ToString());


        }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int IdCategoria { get; set; }
        public bool Ativo { get; set; }
        public EnumCategoria NomeCategoria { get; set; }

    }
}
