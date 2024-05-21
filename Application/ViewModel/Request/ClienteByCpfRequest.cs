using Domain.Entities.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class ClienteByCpfRequest : IValidatableObject
    {

        [Cpf]
        [FromRoute(Name = "cpfCliente")]
        public string CpfCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (string.IsNullOrWhiteSpace(CpfCliente))
                yield return new ValidationResult("CPF é obrigatório", new string[] { "CpfCliente" });


        }

    }
}
