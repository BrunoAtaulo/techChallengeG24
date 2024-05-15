using Domain.Entities.Input;
using Domain.Entities.Output;
using Domain.Entities.Validator;
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
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(Cliente))]
        [SwaggerResponse(204, "Requisi��o conclu�da, por�m n�o h� dados de retorno!")]
        [SwaggerResponse(206, "Conte�do parcial!", typeof(IList<Cliente>))]
        [SwaggerResponse(412, "Condi��o pr�via dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet("{cpfCliente}")]
        [SwaggerOperation(
            Summary = "Busca informa��es de cadastro de um determinado cliente.",
            Description = @"Endpoint para buscar informa��es de um determinado cliente. A busca pode ser feita pelo filtro abaixo:</br></br>
                            <b>Par�metros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>:  CPF do cliente cadastrado. &rArr; <font color='red'><b>Obrigat�rio</b></font>",
            Tags = new[] { "Clientes" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCliente([FromRoute] ClientesByCpf filtro)
        {

            return Ok();
        }
        #endregion

        #region POST/clientes
        [SwaggerResponse(201, "A solicita��o foi atendida e resultou na cria��o de um ou mais novos recursos.", typeof(ClienteById))]
        [SwaggerResponse(400, "A solicita��o n�o pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisi��o requer autentica��o do usu�rio!")]
        [SwaggerResponse(403, "Privil�gios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado n�o existe!")]
        [SwaggerResponse(412, "Condi��o pr�via dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condi��o inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
         Summary = "Endpoint para cria��o de cliente na lanchonete.",
         Description = @"Endpoint para cadastrar um novo cliente.</br></br>
                            <b>Par�metros de entrada:</b></br></br>
                             &bull; <b>CPF</b>:  CPF do cliente. &rArr; <font color='red'><b>Obrigat�rio</b></font><br>
                         &bull; <b>Email</b>: CPF do cliente. &rArr; <font color='red'><b>Obrigat�rio</b></font><br>
                         &bull; <b>Nome</b>: Nome do cliente. &rArr; <font color='red'><b>Obrigat�rio</b></font><br>
                         &bull; <b>Sobrenome</b>: Sobrenome do cliente. &rArr; <font color='red'><b>Obrigat�rio</b></font><br>
                        &bull; <b>NomeSocial</b>: Apelido/Nome Social do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
         Tags = new[] { "Clientes" }
     )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCliente([FromBody] Clientes filtro)
        {
            return Ok();
        }

        #endregion

        #region DELETE/clientes/{cpfCliente}
        [SwaggerResponse(200, "Deletado com sucesso!")]
        [SwaggerResponse(400, "A solicita��o n�o pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisi��o requer autentica��o do usu�rio!")]
        [SwaggerResponse(403, "Privil�gios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado n�o existe!")]
        [SwaggerResponse(412, "Condi��o pr�via dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condi��o inesperada!")]
        [HttpDelete("{cpfCliente}")]
        [SwaggerOperation(
           Summary = "Endpoint para deletar cliente do sistema.",
           Description = @"Endpoint para deletar informa��es de um determinado cliente. </br></br>
                            <b>Par�metros de entrada:</b></br></br>
                             &bull; <b>idCliente</b>:  Identificador �nico do cliente. &rArr; <font color='red'><b>Obrigat�rio</b></font>",
           Tags = new[] { "Clientes" }
       )]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteCliente([FromRoute] ClientesByCpf filtro)
        {
            return Ok();
        }
        #endregion

        #region PATCH/clientes
        [SwaggerResponse(201, "A solicita��o foi atendida e resultou na cria��o de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicita��o n�o pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisi��o requer autentica��o do usu�rio!")]
        [SwaggerResponse(403, "Privil�gios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado n�o existe!")]
        [SwaggerResponse(412, "Condi��o pr�via dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condi��o inesperada!")]
        [HttpPatch("{cpfCliente}")]
        [SwaggerOperation(
      Summary = "Endpoint para atualizar dados de um cliente.",
      Description = @"Endpoint para atualizar informa��es de um determinado cliente.</br></br>
                            <b>Par�metros de entrada:</b></br></br>
                            &bull; <b>CpfCliente</b>:  Cpf do cliente. &rArr; <font color='red'><b>Obrigat�rio</b></font>                        
                         &bull; <b>Email</b>: Email do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>Nome</b>: Nome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>Sobrenome</b>: Sobrenome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                        &bull; <b>Nome social</b>: Apelido/Nome Social do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
      Tags = new[] { "Clientes" }
  )]
        [Consumes("application/json")]
        public async Task<IActionResult> PatchCliente([FromRoute] ClientesByCpf idCliente, [FromBody] PatchClientes filtro)
        {
            return Ok();
        }
        #endregion

    }
}