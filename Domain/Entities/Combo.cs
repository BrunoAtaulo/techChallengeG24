using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Combo
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
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
