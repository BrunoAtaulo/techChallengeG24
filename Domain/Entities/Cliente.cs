using Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Cliente
    {
        public Cliente(string cpf, string nome, string sobreNome, string email, string nomeSocial)
        {
            Cpf = cpf;
            Nome = nome;
            SobreNome = sobreNome;
            Email = email;
            NomeSocial = nomeSocial;
            DataCadastro = DateTime.Now;
            ValidateEntity();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Cpf { get; set; }
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        public string NomeSocial { get; set; }

        public DateTime DataCadastro { get; set; }


        #region Validations


        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Cpf, "O nome não pode estar vazio!");

            AssertionConcern.AssertArgumentNotEmpty(Nome, "O nome não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Email, "O email não pode estar vazio!");

        }
        #endregion
    }
}
