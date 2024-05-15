using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ComboProduto
    {
        [Key]
        public int Id { get; set; }
        public Produto produto { get; set; }
        public Combo Combo { get; set; }

    }


}
