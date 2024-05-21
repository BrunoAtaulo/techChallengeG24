using Application.ViewModel.Output;
using Domain.Base;
using System.Collections.Generic;

namespace Application.ViewModel.Request
{
    public class CategoriaRequest
    {
        public int IdCategoria { get; set; }
        
        public EnumCategoria NomeCategoria { get; set; }
        
        public List<Produto> Produtos { get; set; }
    }
}
