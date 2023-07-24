using Emprestimo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestimo.Infra.Data.Maps
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idPessoa")
                .UseIdentityColumn();
            
            builder.Property(c => c.Nome)
                .HasColumnName("nome");
            
            //builder.Property(c => c.Telefone)
            //    .HasColumnName("telefone");


            builder.HasMany(c => c.Emprestimos)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(p => p.Id);
;        }
    }
}
