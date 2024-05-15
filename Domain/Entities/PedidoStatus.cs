using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class PedidoStatus
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }


}
