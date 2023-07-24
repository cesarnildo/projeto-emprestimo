using Emprestimo.Domain.Validations;

namespace Emprestimo.Domain.Entities
{
    public sealed class Emprestimos
    {
        public int Id { get; private set; }
        public int IdPessoa { get; private set; }
        public int IdJogo { get; private set; }
        public DateTime? DtRetirada { get; private set; }
        public DateTime? DtEntrega { get; private set; }


        public Pessoa Pessoa { get; set; }
        public Jogos Jogos { get; set; }

        
        public Emprestimos(int idPessoa,int idJogo)
        {
            Validations(idPessoa, idJogo); 
        }

        public Emprestimos(int id,int idPessoa, int idJogo)
        {
            DomainValitationException.When(id <= 0, "Id deve ser informado");
            Id = id;
            Validations(idPessoa, idJogo);
        }

        private void Validations(int idPessoa,int idJogo)
        {
            DomainValitationException.When(idPessoa <= 0, "Id Pessoa deve ser informado");
            DomainValitationException.When(idJogo <= 0, " Id Jogo deve ser informado");
   
            IdPessoa    = idPessoa;
            IdJogo      = idJogo;
            DtRetirada  = DateTime.Now;




        }



    }
}
