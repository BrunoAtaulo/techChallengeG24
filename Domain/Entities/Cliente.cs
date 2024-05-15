using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Cpf { get; set; }
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public string NomeSocial { get; set; }

        public DateTime DataCadastro { get; set; }


        #region Validations
        public void Validate()
        {
            ValidaNome();
        }

        private void ValidaNome()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new Exception("por favor, informe o nome.");

        }
        #endregion
    }
}
