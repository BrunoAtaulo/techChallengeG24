using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class PatchClienteRequest
    {
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string EmailCliente { get; set; }
        public string NomeCliente { get; set; }
        public string SobrenomeCliente { get; set; }
        public string NomeSocialCliente { get; set; }
    }
}
