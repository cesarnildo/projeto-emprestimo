using Emprestimo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emprestimo.Infra.Data.Maps
{
    public class JogosMap : IEntityTypeConfiguration<Jogos>
    {
        public void Configure(EntityTypeBuilder<Jogos> builder)
        {
            builder.ToTable("Jogos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("idJogo")
                .UseIdentityColumn();

            builder.Property(c => c.Descricao)
               .HasColumnName("descricao");

            builder.Property(c => c.flDisponivel)
                .HasColumnName("flDisponivel");

            builder.HasMany(c => c.Emprestimos)
               .WithOne(p => p.Jogos)
               .HasForeignKey(p => p.Id);


        }
    }
}
