using Application.Interfaces;
using Application.Services;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
        [HttpGet("{idPedido}")]
        [SwaggerOperation(
            Summary = "Busca todos os pedidos realizados.",
            Description = @"Endpoint para buscar todos os pedidos que foram realizados. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>                           
                             &bull; <b>idPedido</b>:  Id do pedido. &rArr; <font color='green'><b>Obrigatório</b></font><br>
                        &bull; <b>pedidoStatus</b>: Status atual do pedido. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Recebido<br/>
                             <strong> 2 = </strong> Em preparação<br/>
                             <strong> 3 = </strong>  Pronto<br/>
                             <strong> 4 = </strong> Finalizado                 
                        &bull; <b>pedidoPagamento</b>: Status atual do pagamento. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Pendente<br/>
                             <strong> 2 = </strong> Aprovado<br/>
                             <strong> 3 = </strong> Cancelado                                                 
",
            Tags = new[] { "Pedidos" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetPedidos( [FromRoute] PedidoRequest filtro)
        {

            try
            {
                var rtn = await _pedidoService.GetPedidosAsync(filtro);
                if (rtn == null)
                {
                    return NoContent();
                }

                return Ok(rtn);
            }
            catch (CustomValidationException ex)
            {
                var errorResponse = ex.Error;
                return StatusCode(412, errorResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro inesperado.");
            }
  
        }

        #endregion

        #region POST/pedidos
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.", typeof(PedidoByIdResponse))]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
         Summary = "Endpoint para criação de um novo pedido.",
         Description = @"Endpoint criar um novo pedido.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idCliente</b>:  Id do cliente que realizou o pedido. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>dataPedido</b>: Data em que o pedido foi realizado. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>pedidoStatus</b>: Status atual do pedido. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                             <strong> 1 = </strong> Recebido<br/>
                             <strong> 2 = </strong> Em preparação<br/>
                             <strong> 3 = </strong>  Pronto<br/>
                             <strong> 4 = </strong> Finalizado   
                         

",
         Tags = new[] { "Pedidos" }
     )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostPedido([FromBody] PostPedidoRequest filtro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var rtn = await _pedidoService.PostPedidos(filtro);
                return CreatedAtAction(nameof(PostPedido), new { id = rtn.IdPedido }, rtn);
            }
            catch (CustomValidationException ex)
            {
                var errorResponse = ex.Error;
                return StatusCode(412, errorResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro inesperado.");
            }
        }
        
        #endregion

        #region PATCH/pedidos/{idPedido}
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPatch("{idPedido}")]
        [SwaggerOperation(
        Summary = "Endpoint para atualização do status de um pedido.",
        Description = @"Endpoint atualizar o pedido.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idPedido</b>:  Id do pedido que irá ser atualizado. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>pedidoStatus</b>: Status do pedido. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                             <strong> 1 = </strong> Recebido<br/>
                             <strong> 2 = </strong> Em preparação<br/>
                             <strong> 3 = </strong>  Pronto<br/>
                             <strong> 4 = </strong> Finalizado   
                        

",
        Tags = new[] { "Pedidos" }
    )]
        [Consumes("application/json")]
        public async Task<IActionResult> PatchPedido([FromRoute] int idPedido, [FromQuery] PatchStatusPedidoRequest filtro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var success = await _pedidoService.UpdatePedidoStatusAsync(idPedido, filtro.PedidoStatus.Value);

                if (!success)
                {
                    return NotFound("Pedido não encontrado.");
                }

                return Ok("Status do pedido atualizado com sucesso.");
            }
            catch (CustomValidationException ex)
            {
                var errorResponse = ex.Error;
                return StatusCode(412, errorResponse);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro inesperado.");
            }
        }
    }
        #endregion

       

    
}