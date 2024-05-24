using Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Validator
{
    public class CategoriaValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (string.IsNullOrEmpty(value?.ToString() ?? "") || value.ToString() == "0")
                return new ValidationResult($"O {validationContext.DisplayName} é obrigatorio.", new[] { validationContext.MemberName });


            if (!Enum.IsDefined(typeof(EnumCategoria), value))
                return new ValidationResult($"O {validationContext.DisplayName} nao esta no formato correto.", new[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
