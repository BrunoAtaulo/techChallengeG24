using System;
using Domain.Base;

namespace Application.ViewModel.Output
{
    public class Categoria
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public string NomeProduto { get; set; }
        public EnumCategoria NomeCategoria { get; set; }
    }
}
