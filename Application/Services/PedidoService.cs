using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using System;
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


        public async Task<PedidoResponse> GetPedidosAsync(PedidoRequest filtro)
        {
            var pedidos = await _pedidoRepository.GetPedidoByIdAsync(filtro.IdPedido);
            if (pedidos == null) return null;

            return new PedidoResponse
            {
                IdCliente = pedidos.ClienteId,
                IdPedido = pedidos.Id,
                DataPedido = pedidos.DataPedido,
                PedidoStatus = (EnumPedidoStatus?)pedidos.PedidoStatusId,
                PedidoPagamento = (EnumPedidoPagamento?)pedidos.PedidoPagamentoId

            };
        }


        public async Task<bool> UpdatePedidoStatusAsync(int idPedido, EnumPedidoStatus pedidoStatus)
        {
            var pedido = await _pedidoRepository.GetPedidoByIdAsync(idPedido);
            if (pedido == null)
            {
                return false;
            }



            pedido.PedidoStatusId = (int)pedidoStatus;
            return await _pedidoRepository.UpdatePedidoAsync(pedido);
        }
    }





}