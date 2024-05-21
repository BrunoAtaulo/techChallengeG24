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
    [Route("clientes/")]
    public class ClientesController : ControllerBase
    {


        #region [GET/clientes/{cpfCliente}]
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(Application.ViewModel.Output.Cliente))]
        [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!")]
        [SwaggerResponse(206, "Conteúdo parcial!", typeof(IList<Application.ViewModel.Output.Cliente>))]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet("{cpfCliente}")]
        [SwaggerOperation(
            Summary = "Busca informações de cadastro de um determinado cliente.",
            Description = @"Endpoint para buscar informações de um determinado cliente. A busca pode ser feita pelo filtro abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>:  CPF do cliente cadastrado. &rArr; <font color='red'><b>Obrigatório</b></font>",
            Tags = new[] { "Clientes" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCliente([FromRoute] ClienteByCpf filtro)
        {

            return Ok();
        }
        #endregion

        #region POST/clientes
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.", typeof(ClienteById))]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
         Summary = "Endpoint para criação de cliente na lanchonete.",
         Description = @"Endpoint para cadastrar um novo cliente.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>:  CPF do cliente. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>emailCliente</b>: CPF do cliente. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>nomeCliente</b>: Nome do cliente. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>sobrenomeCliente</b>: Sobrenome do cliente. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>nomeSocialCliente</b>: Apelido/Nome Social do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
         Tags = new[] { "Clientes" }
     )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCliente([FromBody]   Application.ViewModel.Request.ClienteRequest filtro)
        {
            return Ok();
        }

        #endregion

        #region DELETE/clientes/{cpfCliente}
        [SwaggerResponse(200, "Deletado com sucesso!")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpDelete("{cpfCliente}")]
        [SwaggerOperation(
           Summary = "Endpoint para deletar cliente do sistema.",
           Description = @"Endpoint para deletar informações de um determinado cliente. </br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>: Cpf do cliente cadastrado no sistema. &rArr; <font color='red'><b>Obrigatório</b></font>",
           Tags = new[] { "Clientes" }
       )]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteCliente([FromRoute] ClienteByCpf filtro)
        {
            return Ok();
        }
        #endregion

        #region PATCH/clientes
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPatch("{cpfCliente}")]
        [SwaggerOperation(
      Summary = "Endpoint para atualizar dados de um cliente.",
      Description = @"Endpoint para atualizar informações de um determinado cliente.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                            &bull; <b>cpfCliente</b>:  Cpf do cliente. &rArr; <font color='red'><b>Obrigatório</b></font>                        
                         &bull; <b>emailCliente</b>: Email do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>nomeCliente</b>: Nome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>sobrenomeCliente</b>: Sobrenome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                        &bull; <b>nomeSocialCliente</b>: Apelido/Nome Social do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
      Tags = new[] { "Clientes" }
  )]
        [Consumes("application/json")]
        public async Task<IActionResult> PatchCliente([FromRoute] ClienteByCpf idCliente, [FromBody] PatchCliente filtro)
        {
            return Ok();
        }
        #endregion

       
    }
}