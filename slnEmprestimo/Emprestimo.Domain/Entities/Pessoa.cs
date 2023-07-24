using Emprestimo.Domain.Validations;

namespace Emprestimo.Domain.Entities
{
    public sealed class Pessoa
    {
     
        public int Id { get; private set; }
        public string Nome { get; private set; }
        //public string Telefone { get; private set; }

        public ICollection<Emprestimos> Emprestimos { get; set; }

        public Pessoa()
        {
            
        }
        public Pessoa(string nome)
        {
            Validations(nome);
            Emprestimos = new List<Emprestimos>();
        }

        public Pessoa(int id, string nome)
        {
            DomainValitationException.When(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validations(nome);
            Emprestimos = new List<Emprestimos>();
        }

        private void Validations(string nome)
        {
            DomainValitationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado");
            //DomainValitationException.When(string.IsNullOrEmpty(telefone), "O Telefone deve ser informado");

            Nome = nome;
            //Telefone = nome;

        }

    }
}
