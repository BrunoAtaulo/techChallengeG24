using Application.ViewModel.Request;
using Domain.Base;
using Domain.Entities;
using Infra.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//TODO: VALIDAR E AJUSTAR 
namespace Api.Controllers
{
    [ApiController]
    [Route("fakeCheckout/")]
    public class FakeCheckoutController : ControllerBase
    {
        private readonly FiapDbContext _context;

        public FakeCheckoutController(FiapDbContext context)
        {
            _context = context;
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
                        &bull; <b>nomeCliente</b>: Nome do cliente que realizou o(s) pedido(s). &rArr; <font color='green'><b>Opcional</b></font><br>

",
         Tags = new[] { "FakeCheckout" }
     )]
        [Consumes("application/json")]
        public async Task<IActionResult> PostFakeCheckout([FromBody] List<CheckoutRequest> produtos)
        {
            if (produtos == null || produtos.Count == 0)
            {
                return BadRequest(new { error = "A lista de produtos não pode ser nula ou vazia." });
            }
            foreach (var item in produtos)
            {
                var produto = await _context.Produtos.FindAsync(item.IdProduto);
                if (produto == null)
                {
                    return NotFound(new { error = $"Produto com Id {item.IdProduto} não encontrado." });
                }

                var fakeCheckout = new FakeCheckout
                {
                    Produto = produto,
                    Quantidade = item.Quantidade,
                    NomeCliente = item.NomeCliente
                };

                _context.Checkout.Add(fakeCheckout);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFilaDePedidos), null, new { message = "Produtos enviados para a fila com sucesso!" });
        }

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
      Description = @"Este endpoint busca todos os produtos que estão na fila de pedidos, sem finalizar o pedido.</br></br> ",                    

      Tags = new[] { "FakeCheckout" }
  )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetFilaDePedidos()
        {
            var filaDePedidos = await _context.Checkout
                .Include(fc => fc.Produto)
                .ToListAsync();

            var filaComTotal = filaDePedidos.Select(item => new
            {
                id = item.Id,
                produto = new
                {
                    id = item.Produto.Id,
                    categoriaId = item.Produto.CategoriaId,
                    categoria = ((EnumCategoria)item.Produto.CategoriaId).ToString(),
                    nome = item.Produto.Nome,
                    preco = item.Produto.Preco

                },
                quantidade = item.Quantidade,
                nomeCliente = item.NomeCliente,
                valorTotal = item.Quantidade * item.Produto.Preco
            });

            return Ok(filaComTotal);
        }
        #endregion
    }
}

#endregion



