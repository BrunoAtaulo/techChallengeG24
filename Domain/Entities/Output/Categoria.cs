using System;
using Domain.Base;

namespace Domain.Entities.Output
{
    public class Categoria
    {
        public int IdProduto { get; set; }
        public int IdCategoria { get; set; }
        public string NomeProduto { get; set; }
        public EnumCategoria NomeCategoria { get; set; }
    }
}
