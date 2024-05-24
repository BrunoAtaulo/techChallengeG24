using Domain.Entities.Validator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class ClienteRequest : IValidatableObject
    {
        [Cpf]
        public string CpfCliente { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido")]
        public string EmailCliente { get; set; }

        public string NomeCliente { get; set; }

        public string SobrenomeCliente { get; set; }

        public string NomeSocialCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (string.IsNullOrWhiteSpace(CpfCliente) || CpfCliente == "string")
                yield return new ValidationResult("CPF é obrigatório", new string[] { "CpfCliente" });

            if (string.IsNullOrWhiteSpace(EmailCliente) || EmailCliente == "user@example.com")
                yield return new ValidationResult("Email é obrigatório", new string[] { "EmailCliente" });

            if (string.IsNullOrWhiteSpace(NomeCliente) || NomeCliente == "string")
                yield return new ValidationResult("Nome é obrigatório", new string[] { "NomeCliente" });

            if (string.IsNullOrWhiteSpace(SobrenomeCliente) || SobrenomeCliente == "string")
                yield return new ValidationResult("Sobrenome é obrigatório", new string[] { "SobrenomeCliente" });

        }


    }
}
