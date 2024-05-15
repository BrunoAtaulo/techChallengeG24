﻿using System.Collections.Generic;

namespace Domain.Entities.Validator
{
    public class ErrorValidacao
    {
        public string MensagemErro { get; set; }

        public List<ResultError> ListaErros { get; set; }
    }

    public class ResultError
    {
        public string MensagemErro { get; set; }

        public string CampoErro { get; set; }
    }

}
