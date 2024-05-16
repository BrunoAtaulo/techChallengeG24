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
            Summary = "Busca todos os produtos realizados.",
            Description = @"Endpoint para retornar os produtos que foram cadastrados no sistema. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                            &bull; <b>idProduto</b>:  Id do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>nomeProduto</b>:  Nome do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>ValorProduto</b>:  Valor do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>IdCategoria</b>:  Id da categoria do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             &bull; <b>NomeCategoria</b>:  Nome da categoria do produto, escolher 1 item da lista. &rArr; <font color='green'><b>Opcional</b></font><br>
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



    }
}