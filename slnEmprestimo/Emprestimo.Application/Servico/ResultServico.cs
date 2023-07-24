using FluentValidation.Results;

namespace Emprestimo.Application.Servico
{
    public class ResultServico
    {
        public bool isSucesso { get; set; }
        public string Mensagem { get; set; }
        public ICollection<ErrorValidacao> Erros { get; set; }


        public static ResultServico RequestError(string message, ValidationResult validationResult)
        {
            return new ResultServico
            {
                isSucesso = false,
                Mensagem = message,
                Erros = validationResult.Errors.Select(x => new ErrorValidacao { field = x.PropertyName, message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultServico<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultServico<T>
            {
                isSucesso = false,
                Mensagem = message,
                Erros = validationResult.Errors.Select(x => new ErrorValidacao { field = x.PropertyName, message = x.ErrorMessage }).ToList()
            };
        }

        public static ResultServico Fail(string message) => new ResultServico { isSucesso = false, Mensagem = message };
        public static ResultServico<T> Fail<T>(string message) => new ResultServico<T> { isSucesso = false, Mensagem = message };

        public static ResultServico Ok(string message) => new ResultServico { isSucesso = true, Mensagem = message };
        public static ResultServico<T> Ok<T>(T data) => new ResultServico<T> { isSucesso = true, Data = data };



    }

    public class ResultServico<T>: ResultServico
    {
        public T Data { get; set; }
    }
}
