using Application.Interfaces;
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
    [Route("clientes/")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        #region [GET/clientes/{cpfCliente}]
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(ClienteResponse))]
        [SwaggerResponse(204, "Requisicao concluida, porem nao ha dados de retorno!")]
        [SwaggerResponse(206, "Conteudo parcial!", typeof(IList<ClienteResponse>))]
        [SwaggerResponse(412, "condicao previa dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet("{cpfCliente}")]
        [SwaggerOperation(
            Summary = "Busca informacoes de cadastro de um determinado cliente.",
            Description = @"Endpoint para buscar informacoes de um determinado cliente. A busca pode ser feita pelo filtro abaixo:</br></br>
                            <b>Parametros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>:  CPF do cliente cadastrado. &rArr; <font color='red'><b>Obrigatorio</b></font>",
            Tags = new[] { "Clientes" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCliente([FromRoute] ClienteByCpfRequest filtro)
        {

            try
            {
                var rtn = await _clienteService.GetClienteByCpf(filtro);
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

        #region POST/clientes
        [SwaggerResponse(201, "A solicitacao foi atendida e resultou na criacao de um ou mais novos recursos.", typeof(ClienteByIdResponse))]
        [SwaggerResponse(400, "A solicitacao nao pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisicao requer autenticacao do usuario!")]
        [SwaggerResponse(403, "Privilegios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado nao existe!")]
        [SwaggerResponse(412, "Condicao previa dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condicao inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
         Summary = "Endpoint para criacao de cliente na lanchonete.",
         Description = @"Endpoint para cadastrar um novo cliente.</br></br>
                            <b>Parametros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>:  CPF do cliente. &rArr; <font color='red'><b>Obrigatorio</b></font><br>
                         &bull; <b>emailCliente</b>: CPF do cliente. &rArr; <font color='red'><b>Obrigatorio</b></font><br>
                         &bull; <b>nomeCliente</b>: Nome do cliente. &rArr; <font color='red'><b>Obrigatorio</b></font><br>
                         &bull; <b>sobrenomeCliente</b>: Sobrenome do cliente. &rArr; <font color='red'><b>Obrigatorio</b></font><br>
                        &bull; <b>nomeSocialCliente</b>: Apelido/Nome Social do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
         Tags = new[] { "Clientes" }
     )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCliente([FromBody] ClienteRequest filtro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var rtn = await _clienteService.PostClientes(filtro);
                return CreatedAtAction(nameof(PostCliente), new { id = rtn.IdCliente }, rtn);
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

        #region DELETE/clientes/{cpfCliente}
        [SwaggerResponse(200, "Deletado com sucesso!")]
        [SwaggerResponse(400, "A solicitacao nao pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisicao requer autenticacao do usuario!")]
        [SwaggerResponse(403, "Privilegios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado nao existe!")]
        [SwaggerResponse(412, "Condicao previa dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condicao inesperada!")]
        [HttpDelete("{cpfCliente}")]
        [SwaggerOperation(
           Summary = "Endpoint para deletar cliente do sistema.",
           Description = @"Endpoint para deletar informacoes de um determinado cliente. </br></br>
                            <b>Parametros de entrada:</b></br></br>
                             &bull; <b>cpfCliente</b>: Cpf do cliente cadastrado no sistema. &rArr; <font color='red'><b>Obrigatorio</b></font>",
           Tags = new[] { "Clientes" }
       )]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteCliente([FromRoute] ClienteByCpfRequest filtro)
        {
            try
            {
                await _clienteService.DeleteClienteByCpf(filtro);
                return Ok("Deletado com sucesso!");
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

        #region PATCH/clientes
        [SwaggerResponse(201, "A solicitacao foi atendida e resultou na criacao de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitacao nao pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisicao requer autenticacao do usuario!")]
        [SwaggerResponse(403, "Privilegios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado nao existe!")]
        [SwaggerResponse(412, "Condicao previa dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condicao inesperada!")]
        [HttpPatch("{cpfCliente}")]
        [SwaggerOperation(
      Summary = "Endpoint para atualizar dados de um cliente.",
      Description = @"Endpoint para atualizar informacoes de um determinado cliente.</br></br>
                            <b>Parametros de entrada:</b></br></br>
                            &bull; <b>cpfCliente</b>:  Cpf do cliente. &rArr; <font color='red'><b>Obrigatorio</b></font>                        
                         &bull; <b>emailCliente</b>: Email do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>nomeCliente</b>: Nome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>sobrenomeCliente</b>: Sobrenome do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>
                        &bull; <b>nomeSocialCliente</b>: Apelido/Nome Social do cliente. &rArr; <font color='green'><b>Opcional</b></font><br>

",
      Tags = new[] { "Clientes" }
  )]
        [Consumes("application/json")]
        public async Task<IActionResult> PatchCliente([FromRoute] ClienteByCpfRequest cpf, [FromBody] PatchClienteRequest filtro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _clienteService.UpdateClienteByCpf(new ClienteByCpfRequest { CpfCliente = cpf.CpfCliente }, filtro);

                return Ok("Dados do cliente atualizados com sucesso.");
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


    }
}