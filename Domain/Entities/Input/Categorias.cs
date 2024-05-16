using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.Entities.Input
{
    public class Categorias
    {
        public int IdCategoria { get; set; }
        
        public EnumCategoria NomeCategoria { get; set; }
        
        public List<Produtos> Produtos { get; set; }
    }
}
