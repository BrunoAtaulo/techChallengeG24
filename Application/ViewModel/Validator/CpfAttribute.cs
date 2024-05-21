using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Validator
{
    public class CpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cpf = value as string;
            if (string.IsNullOrEmpty(cpf))
                return ValidationResult.Success;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return new ValidationResult("O CPF deve ter 11 dígitos.", new[] { validationContext.MemberName });

            var soma = 0;
            var tamanho = 10;

            for (var i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * tamanho;
                tamanho--;
            }

            var digitoVerificador = soma % 11;

            if (digitoVerificador < 2)
                digitoVerificador = 0;
            else
                digitoVerificador = 11 - digitoVerificador;

            if (digitoVerificador != int.Parse(cpf[9].ToString()))
                return new ValidationResult("CPF inválido.", new[] { validationContext.MemberName });

            soma = 0;
            tamanho = 11;

            for (var i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * tamanho;
                tamanho--;
            }

            digitoVerificador = soma % 11;

            if (digitoVerificador < 2)
                digitoVerificador = 0;
            else
                digitoVerificador = 11 - digitoVerificador;

            if (digitoVerificador != int.Parse(cpf[10].ToString()))
                return new ValidationResult("CPF inválido.", new[] { validationContext.MemberName });

            return ValidationResult.Success;
        }
    }
}
