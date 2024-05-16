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
    [Route("produtos/")]
    public class ProdutosController : ControllerBase
    {

        #region [GET/produtos]
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(Produto))]
        [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!")]
        [SwaggerResponse(206, "Conteúdo parcial!", typeof(IList<Produto>))]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet("")]
        [SwaggerOperation(
            Summary = "Busca todos os produtos.",
            Description = @"Endpoint para retornar os produtos que foram cadastrados no sistema. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                            &bull; <b>idProduto</b>:  Id do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>nomeProduto</b>:  Nome do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>valorProduto</b>:  Valor do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>idCategoria</b>:  Id da categoria do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>nomeCategoria</b>:  Nome da categoria do produto, escolher 1 item da lista. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong>  Bebida<br/>
                             <strong> 4 = </strong> Sobremesa
                        
                        
",
            Tags = new[] { "Produtos" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProdutos([FromQuery] Produtos filtro)
        {

            return Ok();
        }
        #endregion

        #region DELETE/produtos/{IdProduto}
        [SwaggerResponse(200, "Deletado com sucesso!")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpDelete("{idProduto}")]
        [SwaggerOperation(
           Summary = "Endpoint para deletar produto do sistema pelo id.",
           Description = @"Endpoint para deletar um determinado produto.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idProduto</b>:  Identificador único do produto. &rArr; <font color='red'><b>Obrigatório</b></font>",
           Tags = new[] { "Produtos" }
       )]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteProdutos([FromRoute] ProdutosById filtro)
        {
            return Ok();
        }
        #endregion

        #region GET/categorias/{idCategoria}
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(Categoria))]
        [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!")]
        [SwaggerResponse(206, "Conteúdo parcial!", typeof(IList<Categoria>))]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        [HttpGet("/categorias/{idCategoria}/produtos")]
        [SwaggerOperation(
        Summary = "Busca a categoria de produtos.",
        Description = @"Endpoint para buscar a categoria de produtos. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>                          
                             &bull; <b>idCategoria</b>:  Id da categoria. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                             <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong> Bebida<br/>
                             <strong> 4 = </strong> Sobremesa
                                          
",
        Tags = new[] { "Produtos" }
    )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetCategoriaProduto([FromRoute] CategoriasById filtro)
        {

            return Ok();
        }
        #endregion

        #region POST/produtos
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.", typeof(ProdutoById))]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
       Summary = "Endpoint para criação de um novo produto.",
       Description = @"Endpoint para criar um novo produto.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>nomeProduto</b>:  Nome do produto. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                              &bull; <b>descricaoProduto</b>: Descrição do produto que está sendo cadastrado. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                         &bull; <b>valorProduto</b>: Valor do produto. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>quantidadeProduto</b>: Quantidade do produto que está sendo cadastrado. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>idCategoria</b>: ID da categoria. Escolher 1 item da lista &rArr; <font color='red'><b>Obrigatório</b></font>                        
                             <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong>  Bebida<br/>
                             <strong> 4 = </strong> Sobremesa                       
",
       Tags = new[] { "Produtos" }
   )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostCliente([FromBody] PostProdutos filtro)
        {
            return Ok();
        }
        #endregion

        #region PATCH/produtos/{idProduto}
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPatch("{idProduto}")]
        [SwaggerOperation(
   Summary = "Endpoint para atualizar produto já existente.",
   Description = @"Endpoint para atualizar produto.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idProduto</b>:  Id do produto que deseja atualizar. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                            &bull; <b>nomeProduto</b>: Nome do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                              &bull; <b>descricaoProduto</b>: Descrição do produto já cadastrado. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>valorProduto</b>: Valor do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                        &bull; <b>quantidadeProduto</b>: Quantidade do produto já cadastrado. &rArr; <font color='green'><b>Opcional</b></font><br>
                         &bull; <b>idCategoria</b>: ID da categoria. Escolher 1 item da lista &rArr; <font color='green'><b>Opcional</b></font><br>
                              <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong>  Bebida<br/>
                             <strong> 4 = </strong> Sobremesa                       
",
   Tags = new[] { "Produtos" }
)]
        [Consumes("application/json")]
        public async Task<IActionResult> PatchCliente([FromRoute] ProdutoById idProduto, [FromBody] PatchProdutos filtro)
        {
            return Ok();
        }
        #endregion
    }
}