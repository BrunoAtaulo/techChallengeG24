using System;

namespace Domain.Entities.Output
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string CpfCliente { get; set; }
        public string NomeCliente { get; set; }
        public string SobreNomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string NomeSocialCliente { get; set; }
        public DateTime DataCadastroCliente { get; set; }


    }
}
