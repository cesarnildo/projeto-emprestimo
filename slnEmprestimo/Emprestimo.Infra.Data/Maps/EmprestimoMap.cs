using Emprestimo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestimo.Infra.Data.Maps
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimos>
    {
        public void Configure(EntityTypeBuilder<Emprestimos> builder)
        {
            builder.ToTable("Emprestimo");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
               .HasColumnName("idEmprestimo")
               .UseIdentityColumn();

            builder.Property(c => c.IdPessoa)
               .HasColumnName("idPessoa");


            builder.Property(c => c.IdJogo)
             .HasColumnName("idJogo");
  

            builder.HasOne(x => x.Pessoa)
                .WithMany(x => x.Emprestimos);

            builder.HasOne(x => x.Jogos)
                .WithMany(x => x.Emprestimos);
                


        }
    }
}
