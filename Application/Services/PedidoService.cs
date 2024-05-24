using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
        }
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoByIdResponse> PostPedidos(PostPedidoRequest filtro)
        {

            // Validação de entrada
            if (filtro == null)
                throw new ArgumentNullException(nameof(filtro));

            if (!DateTime.TryParseExact(filtro.DataPedido.ToString(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var dataPedido))
            {
                throw new ArgumentException("Formato de data inválido. Use dd/MM/yyyy.");
            }

            var pedido = new Pedido(
                filtro.IdCliente,
                dataPedido,
                (int)filtro.PedidoStatus.Value
            );

            await _pedidoRepository.PostPedido(pedido);

            var response = new PedidoByIdResponse
            {
                IdPedido = pedido.Id
            };

            return response;
        }

        public async Task<IList<PedidoResponse>> GetPedidosAsync(PedidoRequest filtro)
        {
            var pedidos = await _pedidoRepository.GetPedidosAsync(
                filtro.IdCliente > 0 ? filtro.IdCliente : (int?)null,
                filtro.IdPedido > 0 ? filtro.IdPedido : (int?)null,
                filtro.PedidoStatus,
                filtro.PedidoPagamento,
                filtro.DataPedido != default(DateTime) ? filtro.DataPedido : (DateTime?)null
            );

            return pedidos.Select(p => new PedidoResponse
            {
                IdCliente = p.ClienteId,
                IdPedido = p.Id,
                QuatidadePedido = p.Produtos.Count,
                IdCombo = null, 
                PedidoStatus = (EnumPedidoStatus)p.PedidoStatusId,
                PedidoPagamento = (EnumPedidoPagamento)p.PedidoPagamentoId,
                DataPedido = p.DataPedido
            }).ToList();
        }
    

    #region CustomValidator
    public class CustomValidationException : Exception
        {
            public ErrorValidacao Error { get; }

            public CustomValidationException(ErrorValidacao error)
            {
                Error = error;
            }
        }
        #endregion
    }
}