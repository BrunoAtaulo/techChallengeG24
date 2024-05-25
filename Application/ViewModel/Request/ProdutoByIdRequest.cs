using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModel.Request
{
    public class ProdutoByIdRequest : IValidatableObject
    {
        public int idProduto { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (idProduto <= 0)
                yield return new ValidationResult("Id do produto é obrigatório", new string[] { "IdProduto" });
        }

    }
}
