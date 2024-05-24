using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Domain.Base;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteByIdResponse> PostClientes(ClienteRequest filtro)
        {
            var rtn = new Cliente(
                filtro.CpfCliente,
                filtro.NomeCliente,
                filtro.SobrenomeCliente,
                filtro.EmailCliente,
                filtro.NomeSocialCliente
            );

            await _clienteRepository.PostCliente(rtn);

            return new ClienteByIdResponse
            {
                IdCliente = rtn.Id
            };
        }

        public async Task<ClienteResponse> GetClienteByCpf(ClienteByCpfRequest filtro)
        {
            var cliente = await _clienteRepository.GetCliente(filtro.CpfCliente);
            if (cliente == null) return null;

            return new ClienteResponse
            {
                IdCliente = cliente.Id,
                CpfCliente = cliente.Cpf,
                NomeCliente = cliente.Nome,
                SobreNomeCliente = cliente.SobreNome,
                EmailCliente = cliente.Email,
                NomeSocialCliente = cliente.NomeSocial,
                DataCadastroCliente = cliente.DataCadastro.ToString("dd/MM/yyyy HH:mm:ss")
            };
        }



        public async Task UpdateClienteByCpf(ClienteByCpfRequest cpfCliente, PatchClienteRequest filtro)
        {
            var cliente = await _clienteRepository.GetCliente(cpfCliente.CpfCliente);

            if (cliente == null)
            {
                var errorResponse = new ErrorValidacao
                {
                    MensagemErro = "Cliente não encontrado",
                    ListaErros = new List<ResultError>()
                };

                errorResponse.ListaErros.Add(new ResultError
                {
                    MensagemErro = "Cliente não encontrado",
                    CampoErro = "cpfCliente"
                });

                throw new CustomValidationException(errorResponse);
            }


            if (!string.IsNullOrWhiteSpace(filtro.EmailCliente) && filtro.EmailCliente != "user@example.com")
                cliente.Email = filtro.EmailCliente;

            if (!string.IsNullOrWhiteSpace(filtro.NomeCliente) && filtro.NomeCliente != "string")
                cliente.Nome = filtro.NomeCliente;

            if (!string.IsNullOrWhiteSpace(filtro.SobrenomeCliente) && filtro.SobrenomeCliente != "string")
                cliente.SobreNome = filtro.SobrenomeCliente;

            if (!string.IsNullOrWhiteSpace(filtro.NomeSocialCliente) && filtro.NomeSocialCliente != "string")
                cliente.NomeSocial = filtro.NomeSocialCliente;


            await _clienteRepository.UpdateCliente(cliente);
        }


        public async Task DeleteClienteByCpf(ClienteByCpfRequest cpfCliente)
        {

            var cliente = await _clienteRepository.GetCliente(cpfCliente.CpfCliente);

            if (cliente == null)
            {
                var errorResponse = new ErrorValidacao
                {
                    MensagemErro = "Cliente não encontrado",
                    ListaErros = new List<ResultError>()
                };



                throw new CustomValidationException(errorResponse);
            }


            await _clienteRepository.DeleteCliente(cliente);
        }



    }
}