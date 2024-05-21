using Application.ViewModel.Output;
using Application.ViewModel.Request;
using Domain.Entities.Input;
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

        #region [GET/pedidos]
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(Pedido))]
        [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!")]
        [SwaggerResponse(206, "Conteúdo parcial!", typeof(IList<Pedido>))]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet("")]
        [SwaggerOperation(
            Summary = "Busca todos os pedidos realizados.",
            Description = @"Endpoint para buscar todos os pedidos que foram realizados. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                            &bull; <b>idCliente</b>:  Id do cliente que realizou o pedido. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>idPedido</b>:  Id do pedido. &rArr; <font color='green'><b>Opcional</b></font><br>
                        &bull; <b>pedidoStatus</b>: Status atual do pedido. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Recebido<br/>
                             <strong> 2 = </strong> Em preparação<br/>
                             <strong> 3 = </strong>  Pronto<br/>
                             <strong> 4 = </strong> Finalizado                 
                        &bull; <b>pedidoPagamento</b>: Status atual do pagamento. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Pendente<br/>
                             <strong> 2 = </strong> Aprovado<br/>
                             <strong> 3 = </strong> Cancelado                          
                        &bull; <b>dataPedido</b>: Data em que o pedido foi realizado. &rArr; <font color='green'><b>Opcional</b></font>
",
            Tags = new[] { "Pedidos" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetPedidos([FromQuery]Pedidos filtro)
        {

            return Ok();
        }
        #endregion


        #region POST/pedidos
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.", typeof(PedidoById))]
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
                          &bull;<b>comboPedido</b>: Lista de combos incluídos no pedido, cada um contendo uma lista de produtos:<br>
                       &nbsp;&emsp;<b>produtoPedido</b>: Lista dos produtos incluídos no combo.<br>
                        &nbsp;&emsp;&nbsp;&emsp;&emsp; <b>idProduto</b>: Id do produto que foi incluído no combo. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                       &nbsp;&emsp;&nbsp;&emsp;&emsp; <b>quantidadeProduto</b>: Quantidade do produto incluído no combo. &rArr; <font color='red'><b>Obrigatório</b></font><br>

",
         Tags = new[] { "Pedidos" }
     )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCliente([FromBody] PostPedidos filtro)
        {
            return Ok();
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
        public async Task<IActionResult> PatchPedido([FromRoute] int idPedido, [FromQuery] PatchStatusPedido filtro)
        {
            return Ok();
        }
        #endregion

        #region Post/checkoutPedidos
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPost("/checkoutPedidos")]
        [SwaggerOperation(
       Summary = "Endpoint para criação de um fake checkout do pedido.",
       Description = @"Endpoint para cadastrar um fake checkout.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idPedido</b>:  Id do pedido. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>IdProduto</b>: Id do Produto selecionado podendo ser lanche, bebidas, sobremesas, combo. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>quantidade</b>: Quantidade do produto. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>valorUnitario</b>: Valor de cada produto selecionado. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>nomeCliente</b>: Nome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
       Tags = new[] { "Pedidos" }
   )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCheckoutPedido([FromBody] CheckoutRequest filtro)
        {
            return Ok();
        }


        #endregion


    }
}