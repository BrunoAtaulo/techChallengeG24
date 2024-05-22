using System;

namespace Domain.Base
{
    public class DomainException : Exception
    {
        /// <summary>
        ///  Cria somente uma instancia
        /// </summary>
        public DomainException() { }

        /// <summary>
        /// Passa uma mensagem personalizada
        /// </summary>
        /// <param name="message"></param>
        public DomainException(string message) : base(message) { }

        /// <summary>
        /// Passa uma mensagem e uma exception que iniciou anteriormente e queremos retornar ela
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DomainException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class CustomValidationException : Exception
    {
        public ErrorValidacao Error { get; }

        public CustomValidationException(string message)
        {
            Error = new ErrorValidacao();
            Error.MensagemErro = message;
        }
        public CustomValidationException(ErrorValidacao error)
        {
            Error = error;
        }
    }
}
