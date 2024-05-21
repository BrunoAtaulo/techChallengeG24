using Application.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Domain.Entities.Validator
{
    public class CpfValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(ms => ms.Value.Errors.Count > 0)
                    .Select(ms => new ResultError
                    {
                        CampoErro = ms.Key,
                        MensagemErro = ms.Value.Errors.FirstOrDefault()?.ErrorMessage
                    })
                    .ToList();

                var errorResponse = new ErrorValidacao
                {
                    MensagemErro = "Um ou mais erros de validação ocorreram.",
                    ListaErros = errors
                };

                context.Result = new ObjectResult(errorResponse)
                {
                    StatusCode = 412
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}