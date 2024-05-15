using Domain.Entities.Validator;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Input
{
    public class ClientesByCpf : IValidatableObject
    {
        [Cpf]
        public string CpfCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (string.IsNullOrWhiteSpace(CpfCliente))
                yield return new ValidationResult("CPF é obrigatório", new string[] { "CpfCliente" });


        }

    }
}
