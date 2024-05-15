using Domain.Entities.Validator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class Clientes : IValidatableObject
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

            if (string.IsNullOrWhiteSpace(CpfCliente))
                yield return new ValidationResult("CPF é obrigatório", new string[] { "CpfCliente" });

            if (string.IsNullOrWhiteSpace(EmailCliente))
                yield return new ValidationResult("Email é obrigatório", new string[] { "EmailCliente" });

            if (string.IsNullOrWhiteSpace(NomeCliente))
                yield return new ValidationResult("Nome é obrigatório", new string[] { "NomeCliente" });

            if (string.IsNullOrWhiteSpace(SobrenomeCliente))
                yield return new ValidationResult("Sobrenome é obrigatório", new string[] { "SobrenomeCliente" });

        }


    }
}
