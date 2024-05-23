using Application.Interfaces;
using Application.ViewModel.Request;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("fakeCheckout/")]
    public class FakeCheckoutController : ControllerBase
    {
        private readonly IFakeCheckoutService _service;

        public FakeCheckoutController(IFakeCheckoutService service)
        {
            _service = service;
        }

        #region POST/clientes
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
            Summary = "Endpoint para envio de produtos escolhidos para a fila.",
            Description = @"Este endpoint envia os produtos escolhidos para a fila de pedidos, sem finalizar o pedido.</br></br>
                            <b>Parametros de entrada:</b></br></br>
                            &bull; <b>IdProduto</b>: Id do Produto selecionado podendo ser lanche, bebidas, sobremesas, combo. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                            &bull; <b>quantidade</b>: Quantidade do produto. &rArr; <font color='red'><b>Obrigatório</b></font>                        
                            &bull; <b>nomeCliente</b>: Nome do cliente que realizou o(s) pedido(s). &rArr; <font color='green'><b>Opcional</b></font><br>",
            Tags = new[] { "FakeCheckout" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostFakeCheckout([FromBody] List<CheckoutRequest> produtos)
        {
            var result = await _service.ProcessFakeCheckoutAsync(produtos);

            if (result.Contains("não encontrado") || result.Contains("nula ou vazia"))
            {
                return BadRequest(new { error = result });
            }

            return CreatedAtAction(nameof(GetFilaDePedidos), null, new { message = result });
        }
        #endregion

        #region Get/fakeCheckout
        [SwaggerResponse(200, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpGet("")]
        [SwaggerOperation(
            Summary = "Endpoint para consultar a lista de produtos escolhidos para a fila.",
            Description = @"Este endpoint busca todos os produtos que estão na fila de pedidos, sem finalizar o pedido.</br></br>",
            Tags = new[] { "FakeCheckout" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetFilaDePedidos()
        {
            var filaComTotal = await _service.GetFakeCheckoutsAsync();
            return Ok(filaComTotal);
        }
        #endregion
    }
}
