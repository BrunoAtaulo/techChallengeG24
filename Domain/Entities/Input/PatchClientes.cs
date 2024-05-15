using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class PatchClientes
    {
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string EmailCliente { get; set; }
        public string NomeCliente { get; set; }
        public string SobrenomeCliente { get; set; }
        public string NomeSocialCliente { get; set; }


    }
}
