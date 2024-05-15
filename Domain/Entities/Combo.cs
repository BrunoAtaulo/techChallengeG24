using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Combo
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }


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
