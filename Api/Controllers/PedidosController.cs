using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Api.Controllers
{
    [ApiController]
    [Route("pedidos/")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        #region [GET/pedidos]
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(PedidoResponse))]
        [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!")]
        [SwaggerResponse(206, "Conteúdo parcial!", typeof(IList<PedidoResponse>))]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet()]
        [SwaggerOperation(
            Summary = "Busca todos os pedidos realizados.",
            Description = @"Endpoint para buscar todos os pedidos que foram realizados. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>                           
                             &bull; <b>idPedido</b>:  Id do pedido. &rArr; <font color='green'><b>Opcional</b></font><br>
                        &bull; <b>pedidoStatus</b>: Status atual do pedido. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Recebido<br/>
                             <strong> 2 = </strong> Em preparação<br/>
                             <strong> 3 = </strong>  Pronto<br/>
                             <strong> 4 = </strong> Finalizado                 
                        &bull; <b>pedidoPagamento</b>: Status atual do pagamento. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Pendente<br/>
                             <strong> 2 = </strong> Pago<br/>
                             <strong> 3 = </strong> Cancelado                                                 
",
            Tags = new[] { "Pedidos" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetPedidos([FromQuery] PedidoRequest filtro)
        {


            var rtn = await _pedidoService.GetPedidosAsync(filtro);
            if (rtn == null)
                return NoContent();
            return Ok(rtn);

        }

        #endregion



        #region PATCH/checkout/{idPedido}
        [SwaggerResponse(200, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPatch("{idPedido}/checkout")]
        [SwaggerOperation(
        Summary = "Endpoint para Finalizar o Pagamento do Pedido",
        Description = @"Endpoint atualizar o pedido.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idPedido</b>:  Id do pedido que irá ser atualizado. &rArr; <font color='red'><b>Obrigatório</b></font><br>

",
        Tags = new[] { "Pedidos" }
    )]
        [Consumes("application/json")]
        public async Task<IActionResult> PatchPedido([FromRoute] PedidoIdRequest input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _pedidoService.UpdatePedidoStatusAsync(input);

            if (!success)
                return NotFound("Pedido não encontrado.");


            return Ok("Pedido Pago com sucesso.");

        }
    }
    #endregion




}