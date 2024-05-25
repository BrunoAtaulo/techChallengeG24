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

    
        public async Task<IList<PedidoResponse>> GetPedidosAsync(PedidoRequest filtro)
        {
            var lstPedidos = await _pedidoRepository.GetPedidosAsync(filtro.IdPedido, filtro.PedidoStatus, filtro.PedidoPagamento);
            if (lstPedidos == null)
                return null;
            return lstPedidos.Select(s => new PedidoResponse(s)).ToList();
        }


        public async Task<bool> UpdatePedidoStatusAsync(PedidoIdRequest input)
        {
            var pedido = await _pedidoRepository.GetPedidosByIdAsync(input.idPedido);
            if (pedido == null)
                return false;
            pedido.PedidoPagamentoId = (int)EnumPedidoPagamento.Pago;
            return await _pedidoRepository.UpdatePedidoAsync(pedido);
        }
    }





}