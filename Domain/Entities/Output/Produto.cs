using System;
using Domain.Base;

namespace Domain.Entities.Output
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public DateTime DataCadastroProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int IdCategoria { get; set; }
        public EnumCategoria NomeCategoria { get; set; }
    }
}
