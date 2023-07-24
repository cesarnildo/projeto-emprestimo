namespace Emprestimo.Domain.Validations
{
    public class DomainValitationException: Exception
    {
        public DomainValitationException(string error): base(error)
        {
            
        }

        public static void When(bool hasError, string message)
        {
            if (hasError)
            {
                throw new DomainValitationException(message);
            }
        }
    }
}
