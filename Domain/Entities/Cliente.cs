using Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;

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
        public int Id { get; private set; }

        public string Cpf { get; private set; }
        public string Nome { get; private set; }

        public string SobreNome {  get; private set; }

        public string Email { get; private set; }

        public string NomeSocial { get; private set; }

        public DateTime DataCadastro { get; private set; }


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
