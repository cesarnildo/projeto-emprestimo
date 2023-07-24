using Emprestimo.Domain.Validations;

namespace Emprestimo.Domain.Entities
{
    public sealed class Jogos
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public bool flDisponivel { get; private set; }

        public ICollection<Emprestimos> Emprestimos { get; set; }

        public Jogos()
        {
            
        }
        public Jogos(string descricao)
        {
            Validations(descricao);
            Emprestimos = new List<Emprestimos>();
        }

        public Jogos(int id, string descricao)
        {
            DomainValitationException.When(id < 0, "Id do Jogo deve ser maior que zero");
            Id = id;
            Validations(descricao);
            Emprestimos = new List<Emprestimos>();
        }

        private void Validations(string descricao)
        {
            DomainValitationException.When(string.IsNullOrEmpty(descricao), "A Descrição do Jogo deve ser informado");

            Descricao = descricao;
                     

        }


    }
}
